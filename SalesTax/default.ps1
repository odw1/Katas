Properties {
	$build_dir = Resolve-Path . #Split-Path $psake.build_script_file	
	$build_artifacts_dir = "$build_dir\Build\"
	$tools_dir = "$build_dir\packages"
	$nunit_dir = "$tools_dir\NUnit.2.5.10.11092\tools\"
	$solution = "SalesTax.sln"
	$env:Path += ";$nunit_dir"
}

task Default -depends RunUnitTests

task RunUnitTests -depends Compile {
	RunTests "/exclude=endtoend"
}

task EndToEndTests -depends Compile -description "End to end tests" {
	Write-Host "Executing End To End Tests"
	RunTests "/include=endtoend"
}

task Compile -depends Clean -description "Builds the solution" {	
	Write-Host "Building $solution"
	Exec { msbuild $solution /t:Build /p:Configuration=Release /v:quiet /p:OutDir=""$build_artifacts_dir\"" } 
}

task Clean -description "Removes previous builds" {
	
	Write-Host "Creating BuildArtifacts directory"
	if (Test-Path $build_artifacts_dir) 
	{	
		rd $build_artifacts_dir -rec -force | out-null
	}
	
	mkdir $build_artifacts_dir | out-null
	
	Write-Host "Cleaning $solution"
	Exec { msbuild $solution /t:Clean /p:Configuration=Release /v:quiet } 
}

function RunTests($includeExcludeArg) {
	$testAssemblies = (Get-ChildItem "Build" -Recurse -Include *Tests.dll -Name)
	
	foreach($test_asm_name in $testAssemblies) {
		$file_name = $build_artifacts_dir + "" + $test_asm_name
		Exec {nunit-console.exe $file_name $includeExcludeArg}
	}
}