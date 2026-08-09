# XrmToolBox Bulk Entity Image Uploader & Contact Photo Manager

An enterprise-grade **XrmToolBox Plugin** designed for Microsoft Dynamics 365 and Power Apps (Dataverse). It enables bulk uploading, matching, and updating of record images (`EntityImage` or custom image attributes) for **Contacts**, **Accounts**, **System Users**, **Products**, and custom tables with high-throughput multi-threading.

---

## 🚀 Features at a Glance

- **Multi-Table Support**: Works with standard entities (`contact`, `account`, `systemuser`, `product`) and any custom Dataverse table.
- **Flexible Attribute Mapping**: Match filenames against any string, GUID, email address, or custom identifier (e.g., `employeeid`, `fullname`, `contactid`).
- **Real-Time Progress & Metrics**: Live upload count counter, throughput rate (`files/sec`), elapsed time, and ETA countdown during bulk upload.
- **Advanced Normalization Engine**: Smart string-matching rules to handle whitespace, underscores, hyphens, letter casing, and special characters.
- **Safety & Dry Run Mode**: Preview matches before making any changes in Dataverse, with zero risk.
- **Image Optimization**: Pre-upload client-side resizing and JPEG quality compression to reduce network bandwidth and Dataverse storage consumption.
- **Conflict & Duplicate Management**: Configurable actions for duplicate matches and existing images (Overwrite, Skip, Backup).
- **Comprehensive Audit Logs**: Real-time structured activity logs with one-click export to CSV for compliance and auditing.
- **Developer Code Generator**: Integrated C# source code generator for compiling the plugin DLL locally for XrmToolBox.

---

## 📋 Recommended Workflow & Execution Sequence

Follow these steps sequentially to configure, preview, and perform a bulk image upload:

```
┌─────────────────────────────────────────────────────────────┐
│ 1. Connect to Dataverse Environment (XrmToolBox Connection)│
└──────────────────────────────┬──────────────────────────────┘
                               │
┌──────────────────────────────▼──────────────────────────────┐
│ 2. Select Target Table (e.g., Contact, Account, User)       │
└──────────────────────────────┬──────────────────────────────┘
                               │
┌──────────────────────────────▼──────────────────────────────┐
│ 3. Select Target Image Column (e.g., entityimage)           │
└──────────────────────────────┬──────────────────────────────┘
                               │
┌──────────────────────────────▼──────────────────────────────┐
│ 4. Select Filename Mapping Field (e.g., email, employeeid)  │
└──────────────────────────────┬──────────────────────────────┘
                               │
┌──────────────────────────────▼──────────────────────────────┐
│ 5. Select Local Image Folder (or drag-and-drop batch)       │
└──────────────────────────────┬──────────────────────────────┘
                               │
┌──────────────────────────────▼──────────────────────────────┐
│ 6. Configure Matching & Normalization Rules                 │
└──────────────────────────────┬──────────────────────────────┘
                               │
┌──────────────────────────────▼──────────────────────────────┐
│ 7. Click "Generate Mapping Preview" & Verify Matches        │
└──────────────────────────────┬──────────────────────────────┘
                               │
┌──────────────────────────────▼──────────────────────────────┐
│ 8. Click "Start Bulk Upload" & Monitor Real-Time Progress   │
└─────────────────────────────────────────────────────────────┘
```

### Detailed Sequence Steps:

1. **Connection**:
   - Establish a connection to your target Dynamics 365 / Power Apps Dataverse environment via the XrmToolBox connection bar.

2. **Select Target Dataverse Table**:
   - Navigate to the **Configuration** tab.
   - Search and select the target table (e.g., `Contact`, `Account`, `SystemUser`).

3. **Select Target Image Column**:
   - Choose the target image attribute where the image file will be stored (e.g., `entityimage` for primary photos or any custom `Image` attribute).

4. **Select Filename Mapping Field**:
   - Choose the Dataverse column to match image filenames against. Common options:
     - `emailaddress1` (Matches `john.doe@company.com.jpg`)
     - `fullname` (Matches `John_Doe.png`)
     - `employeeid` (Matches `EMP-10482.jpg`)
     - `contactid` (Matches `b4a2f8d3-1234-5678-90ab-cdef12345678.jpg`)

5. **Select Local Image Folder**:
   - Click **Browse Folder** to select a local directory containing image files (`.jpg`, `.jpeg`, `.png`, `.bmp`, `.gif`, `.webp`).
   - Alternatively, click **Load 1,000+ Demo Batch** to test mapping logic in simulation mode.

6. **Configure Auto-Mapping Normalization Rules**:
   - Adjust the text cleaning options (e.g., `Ignore Spaces`, `Ignore Underscores`) based on your file naming convention.

7. **Generate Mapping Preview**:
   - Click **Generate Mapping Preview** (or **Preview Match**).
   - Switch to the **Preview & Test** tab to inspect the results grid. The grid displays the matched Dataverse Record ID, Full Name, Image Name, and Match Status (`Matched`, `Existing Image`, `Duplicate`, `No Match`).

8. **Execute Bulk Upload & Track Real-Time Progress**:
   - Go to the **Bulk Upload** tab and click **Start Bulk Upload**.
   - Watch the live progress dialog displaying total records, current processed record count, percentage completed, files/sec speed, and estimated time remaining (ETA).

---

## ⚙️ Detailed Explanation of Settings & Normalization Options

The plugin includes a powerful **String Normalization Engine** that cleans both the local image filename (without extension) and the Dataverse field value before performing comparison. This ensures high match rates even when naming conventions differ slightly.

### 1. Matching & Normalization Settings

| Setting Option | Default | Description & Example |
| :--- | :---: | :--- |
| **Case Insensitive** | `TRUE` | Ignores upper and lower case differences during matching.<br>**Example**: `JOHN_DOE.JPG` matches Dataverse value `john_doe`. |
| **Ignore Spaces** | `FALSE` | Removes all blank spaces from both filename and field value.<br>**Example**: `John Smith.jpg` matches Dataverse value `JohnSmith`. |
| **Ignore Underscores (`_`)** | `FALSE` | Strips all underscore characters (`_`) prior to comparison.<br>**Example**: `John_Smith.jpg` matches Dataverse value `JohnSmith` or `John Smith` (if Ignore Spaces is also enabled). |
| **Ignore Hyphens (`-`)** | `FALSE` | Removes all dash/hyphen characters (`-`) from strings.<br>**Example**: `EMP-10482.jpg` matches Dataverse value `EMP10482`. |
| **Trim Leading/Trailing Spaces** | `TRUE` | Strips extra whitespace at the beginning and end of strings.<br>**Example**: `" John.jpg "` becomes `"John"`. |
| **Full Text Normalization** | `FALSE` | Strips diacritics/accents (e.g., `é` -> `e`, `ñ` -> `n`) and removes all non-alphanumeric characters except `@` and `.`.<br>**Example**: `Jörg_Müller.jpg` matches `JorgMuller`. |

---

### 2. Duplicate Record Handling Options

When multiple Dataverse records match a single image filename, the plugin applies one of the following configured conflict rules:

- **Skip Upload (Recommended for Safety)**: Skips uploading the photo for that filename and logs a `Duplicate` warning.
- **Use First Match**: Binds the photo to the first record returned by the Dataverse query.
- **Use Latest Created Record**: Binds the photo to the record with the most recent `createdon` timestamp.
- **Cancel Upload on First Duplicate**: Immediately halts the bulk operation if any duplicate match is encountered.

---

### 3. Upload Execution & Optimization Flags

Located in the **Settings** tab:

- **Overwrite Existing Images**: When enabled, replaces existing images in Dataverse. When disabled, skips records that already have photos attached.
- **Skip Existing Images**: Safely ignores records that already contain an `EntityImage`.
- **Dry Run / Preview Only Mode**: Simulates the full upload process, measuring execution time and logging actions without writing data to Dataverse.
- **Backup Existing Images before Overwrite**: Saves existing Dataverse image payloads as annotation attachments before replacing them.
- **Resize High-Res Images**: Downscales images larger than specified dimensions (e.g., max width `2048px`) to optimize storage.
- **Compress Quality**: Applies configurable JPEG compression (e.g., 85% quality) to reduce file byte payload size.
- **Auto Export Logs to CSV**: Downloads a complete execution CSV log automatically when the bulk batch completes.

---

## 📊 Mapping Match Status Reference

| Status | Meaning |
| :--- | :--- |
| `Matched` | Successfully matched with exactly 1 Dataverse record. Ready to upload. |
| `Existing Image` | Matched with a Dataverse record that already has an existing image. |
| `Duplicate` | Multiple Dataverse records matched the same filename. |
| `No Match` | No corresponding record was found in Dataverse for this filename. |
| `Invalid Image` | File is corrupted, missing, or in an unsupported format. |
| `Uploaded` | Image successfully uploaded to Dataverse. |
| `Failed` | Error occurred during Dataverse Web API call. |

---

## 🛠️ Developer & Build Notes

This application contains both a live React web interface and the full **C# Source Code Generator** for XrmToolBox:

- **C# Code Generator**: Located in `/src/services/csharpCodeGenerator.ts`. It generates compile-ready `.cs` files (`PluginControl.cs`, `UploadEngine.cs`, `WaitProgressDialog.cs`, `DataverseService.cs`, `PluginSettings.cs`) for Visual Studio and XrmToolBox package deployment.
- **Live React Simulator**: Located under `/src/components/tabs/`, providing an identical UI preview of the XrmToolBox WinForms control interface.

---

## 📄 License

This tool is distributed for Microsoft Dynamics 365 / Dataverse administrators, developers, and consultants using XrmToolBox.
