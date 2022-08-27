#!/usr/bin/env pwsh
Get-ChildItem ./ -Include bin,obj,publish -Recurse | ForEach-Object { Remove-Item $_.FullName -Force -Recurse -ErrorAction SilentlyContinue }