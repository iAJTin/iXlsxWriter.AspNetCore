@ECHO OFF
CLS

..\src\.nuget\nuget Pack iXlsxWriter.AspNetCore.1.0.0.nuspec -NoDefaultExcludes -NoPackageAnalysis -OutputDirectory ..\deployment\nuget 

pause

