function configure() {
  $root = '.'
  $src = Join-Path $root 'src'
  $thirdparty = Join-Path $root 'thirdparty'
  $debug = Join-Path $root 'debug'

  return @{
    thirdparty_dir = $thirdparty
    src_dir = $src
    packages_dir = Join-Path $thirdparty 'packages'
    debug_dir = $debug
  }
}

$config = configure

function CheckLastExitCode() {
  if ($? -eq $false) {
    throw 'Command Failed'
  }
}

function tryDelete($path) {
  if (Test-Path($path)) {
    Remove-Item $path -Verbose -Recurse
  }
}

function help() {
  Write-Host -ForegroundColor Green 'Minion Config'
  write-host -ForegroundColor Green (ConvertTo-Json $config)
}

function bootstrap() {
  .\thirdparty\nuget\nuget.exe install .\src\Goul.Nuget.Packages\common\packages.config -OutputDirectory .\thirdparty\packages\common -ExcludeVersion | Write-Host
  .\thirdparty\nuget\nuget.exe install .\src\Goul.Nuget.Packages\net-4.0\packages.config -OutputDirectory .\thirdparty\packages\net-4.5 -ExcludeVersion | Write-Host
}

function clean() {
  tryDelete($config.debug_dir)
}

function cleanAll() {
  tryDelete($config.packages_dir)
}

function runUnitTestsVS() {
  Write-Host -ForegroundColor Cyan '----------VS Unit Tests-----------'
  .\thirdparty\packages\common\nunit.runners\tools\nunit-console.exe .\src\DocumentUploader.UnitTests\bin\debug\DocumentUploader.UnitTests.dll /nologo | Write-Host
  CheckLastExitCode
  Write-Host -ForegroundColor Cyan '----------------------------------'
}

function runUnitTests() {
  Write-Host -ForegroundColor Cyan '-------Debug Unit Tests-----------'
  .\thirdparty\packages\common\nunit.runners\tools\nunit-console.exe .\debug\net-4.0\DocumentUploader.UnitTests\DocumentUploader.UnitTests.dll /nologo | Write-Host
  CheckLastExitCode
  Write-Host -ForegroundColor Cyan '----------------------------------'
}

function runIntegrationTestsVS() {
  Write-Host -ForegroundColor Cyan '------VS Integration Tests--------'
  .\thirdparty\packages\common\nunit.runners\tools\nunit-console.exe .\src\DocumentUploader.IntegrationTests\bin\debug\DocumentUploader.IntegrationTests.dll /nologo | Write-Host
  CheckLastExitCode
  Write-Host -ForegroundColor Cyan '----------------------------------'
}

function runIntegrationTests() {
  Write-Host -ForegroundColor Cyan '-----Debug Integration Tests------'
  .\thirdparty\packages\common\nunit.runners\tools\nunit-console.exe .\debug\net-4.0\DocumentUploader.IntegrationTests\DocumentUploader.IntegrationTests.dll /nologo | Write-Host
  CheckLastExitCode
  Write-Host -ForegroundColor Cyan '----------------------------------'
}

function runAllTests() {
  runUnitTests
  runUnitTestsVS
}

function build() {
  C:\Windows\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe .\src\Goul.Build\Goul.proj /ds /maxcpucount:4 | Write-Host
  CheckLastExitCode
}

function setEnv() {
  $env:PATH += ";.\thirdparty\packages\common\NUnit.Runners\tools"
  Write-Host -ForegroundColor Green 'Path information set'
}

function cycle() {
  build
  runUnitTests
}

function minion {
  param([string[]] $commands)

  $ErrorActionPreference = 'Stop'

  $commands | ForEach {
    $command = $_
    $times = Measure-Command {
      
      Write-Host -ForegroundColor Green "command: $command"
      Write-Host ''
      
      switch ($command) {
        'help' { help }
        'bootstrap' { bootstrap }
        'set.env' { setEnv }
        'clean.all' { 
          clean
          cleanAll 
        }
        'clean' { clean }
        'run.unit.tests' { runUnitTestsVS }
        'run.unit.tests.dbg' { runUnitTests }
        'run.integration.tests' { runIntegrationTestsVS }
        'run.integration.tests.dbg' { runIntegrationTests }
        'run.all.tests' { runAllTests }
        'build' { build }
        'cycle' { cycle }
        default { Write-Host -ForegroundColor Red "command not known: $command" }
      }
    }
    
    Write-Host ''
    Write-Host -ForegroundColor Green "Complete."
  }
}

export-modulemember -function minion