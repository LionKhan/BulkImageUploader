Detailed Sequence Steps:
Connection:

Establish a connection to your target Dynamics 365 / Power Apps Dataverse environment via the XrmToolBox connection bar.
Select Target Dataverse Table:

Navigate to the Configuration tab.
Search and select the target table (e.g., Contact, Account, SystemUser).
Select Target Image Column:

Choose the target image attribute where the image file will be stored (e.g., entityimage for primary photos or any custom Image attribute).
Select Filename Mapping Field:

Choose the Dataverse column to match image filenames against. Common options:
emailaddress1 (Matches john.doe@company.com.jpg)
fullname (Matches John_Doe.png)
employeeid (Matches EMP-10482.jpg)
contactid (Matches b4a2f8d3-1234-5678-90ab-cdef12345678.jpg)
Select Local Image Folder:

Click Browse Folder to select a local directory containing image files (.jpg, .jpeg, .png, .bmp, .gif, .webp).
Alternatively, click Load 1,000+ Demo Batch to test mapping logic in simulation mode.
Configure Auto-Mapping Normalization Rules:

Adjust the text cleaning options (e.g., Ignore Spaces, Ignore Underscores) based on your file naming convention.
Generate Mapping Preview:

Click Generate Mapping Preview (or Preview Match).
Switch to the Preview & Test tab to inspect the results grid. The grid displays the matched Dataverse Record ID, Full Name, Image Name, and Match Status (Matched, Existing Image, Duplicate, No Match).
Execute Bulk Upload & Track Real-Time Progress:

Go to the Bulk Upload tab and click Start Bulk Upload.
Watch the live progress dialog displaying total records, current processed record count, percentage completed, files/sec speed, and estimated time remaining (ETA).