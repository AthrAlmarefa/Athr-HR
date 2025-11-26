import 'package:file_picker/file_picker.dart';
import 'package:open_filex/open_filex.dart';
import 'dart:io';
import 'package:permission_handler/permission_handler.dart';
import 'package:path_provider/path_provider.dart';


Future<PlatformFile?> pickCustomFile() async {
  final result = await FilePicker.platform.pickFiles(
    type: FileType.custom,
    allowedExtensions: ['pdf', 'jpg', 'jpeg', 'png'],
  );

  if (result != null) {
    return result.files.first;
  }

  return null;
}

void openSavedFile(String filePath) {
  OpenFilex.open(filePath);
}



Future<void> downloadCachedFile(String savedPath) async {
  if (savedPath.isEmpty) return;

  var status = await Permission.storage.request();
  if (!status.isGranted) {
    print("Storage permission not granted");
    return;
  }

  try {
    final directory = await getExternalStorageDirectory();
    final downloadsDir = Directory("${directory!.path}/Download");

    if (!downloadsDir.existsSync()) {
      downloadsDir.createSync(recursive: true);
    }

    final fileName = savedPath.split('/').last;
    final destination = "${downloadsDir.path}/$fileName";
    await File(savedPath).copy(destination);

    print("File downloaded at: $destination");
  } catch (e) {
    print("Error downloading file: $e");
  }
}
