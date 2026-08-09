================================================================================
DATAVERSE BULK IMAGE UPLOADER - VISUAL STUDIO 2022 C# SOLUTION
================================================================================

How to open and compile in Visual Studio 2022:

1. Extract this ZIP archive to a folder on your computer.
2. Double click "DataverseBulkImageUploader.sln" to open in Visual Studio 2022.
3. In Visual Studio, right-click the Solution and select "Restore NuGet Packages".
4. Press Ctrl+Shift+B (Build Solution).
5. The compiled plugin DLL will be generated at:
   bin\Release\DataverseBulkImageUploader.dll

How to deploy to XrmToolBox:
- Copy "DataverseBulkImageUploader.dll" to:
  %AppData%\Msdyn365\XrmToolBox\Plugins\

How to publish to XrmToolBox Tool Library Store:
- Run "PublishToNuGetStore.bat" and enter your NuGet.org API key.

Engine Features Included:
- 150,000+ Record Bulk Upload Engine (ExecuteMultipleRequest payload batching)
- WaitProgressDialog WinForms Modal with Real-time speed (uploads/sec), ETA, Pause/Resume, & Cancel
- Automatic Dataverse Service Protection Throttling Auto-Retry (HTTP 429 / 80040265)
================================================================================
