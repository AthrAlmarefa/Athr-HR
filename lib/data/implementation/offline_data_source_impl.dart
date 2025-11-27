import 'dart:io';
import 'package:athr_hr/core/localization/lang_keys.dart';
import 'package:athr_hr/core/utils/extension/my_context.dart';
import 'package:athr_hr/data/contracts/offline_data_source.dart';
import 'package:flutter/material.dart';
import 'package:path_provider/path_provider.dart';
import 'package:permission_handler/permission_handler.dart';
import 'package:shared_preferences/shared_preferences.dart';
import 'package:file_picker/file_picker.dart';
import 'package:open_filex/open_filex.dart';

class OfflineDataSourceImpl implements OfflineDataSource {
  static const String _filePathKey = "saved_file_path";

  @override
  Future<void> cacheFile(PlatformFile file) async {
    try {
      final directory = await getApplicationDocumentsDirectory();
      final savedPath = "${directory.path}/${file.name}";

      await File(file.path!).copy(savedPath);

      final prefs = await SharedPreferences.getInstance();
      await prefs.setString(_filePathKey, savedPath);
    } catch (e) {
      rethrow;
    }
  }

  @override
  Future<String?> getCachedFilePath() async {
    final prefs = await SharedPreferences.getInstance();
    return prefs.getString(_filePathKey);
  }

  @override
  Future<void> deleteCachedFile() async {
    final prefs = await SharedPreferences.getInstance();
    final path = prefs.getString(_filePathKey);

    if (path != null) {
      final file = File(path);
      if (await file.exists()) {
        await file.delete();
      }
      await prefs.remove(_filePathKey);
    }
  }

  Future<PlatformFile?> pickFile(BuildContext context) async {
    final pdf = context.translate(LangKeys.fileTypePdf);
    final jpg = context.translate(LangKeys.fileTypeJpg);
    final jpeg = context.translate(LangKeys.fileTypeJpeg);
    final png = context.translate(LangKeys.fileTypePng);

    final result = await FilePicker.platform.pickFiles(
      type: FileType.custom,
      allowedExtensions: [pdf, jpg, jpeg, png],
    );

    if (result != null) {
      return result.files.first;
    }
    return null;
  }

  Future<void> openFile(String path) async {
    await OpenFilex.open(path);
  }

  Future<bool> downloadFile(String savedPath) async {
    try {
      if (savedPath.isEmpty) return false;

      Directory? downloadsDir;

      if (Platform.isAndroid) {
        var status = await Permission.storage.status;
        if (!status.isGranted) {
          status = await Permission.storage.request();
          if (!status.isGranted) return false;
        }
        downloadsDir = await getExternalStorageDirectory();
        downloadsDir = Directory("${downloadsDir!.path}/MyAppDownloads");
        if (!downloadsDir.existsSync())
          downloadsDir.createSync(recursive: true);
      } else if (Platform.isIOS) {
        downloadsDir = await getApplicationDocumentsDirectory();
      }

      final fileName = savedPath.split('/').last;
      final file = File(savedPath);
      if (!await file.exists()) return false;

      final destination = "${downloadsDir!.path}/$fileName";
      await file.copy(destination);
      return true;
    } catch (e) {
      return false;
    }
  }

  Future<void> handleFileDownload(BuildContext context) async {
    final dataSource = OfflineDataSourceImpl();

    final noFileMsg = context.translate(LangKeys.noFileFoundToDownload);
    final downloadedMsg = context.translate(
      LangKeys.fileDownloadedSuccessfully,
    );
    final failedMsg = context.translate(LangKeys.failedToDownloadFile);

    final path = await dataSource.getCachedFilePath();

    if (path != null) {
      final success = await dataSource.downloadFile(path);

      if (!context.mounted) return;
      ScaffoldMessenger.of(context).showSnackBar(
        SnackBar(content: Text(success ? downloadedMsg : failedMsg)),
      );
    } else {
      if (!context.mounted) return;
      ScaffoldMessenger.of(
        context,
      ).showSnackBar(SnackBar(content: Text(noFileMsg)));
    }
  }

  Future<void> handleFileUpload(BuildContext context) async {
    try {
      final file = await pickFile(context);
      if (file != null) {
        await cacheFile(file);
        print(context.translate(LangKeys.fileSavedSuccessfully));
      }
      final path = await getCachedFilePath();
      if (path != null) {
        await openFile(path);
      }
      ScaffoldMessenger.of(context).showSnackBar(
        SnackBar(
          content: Text(context.translate(LangKeys.fileUploadedSuccessfully)),
        ),
      );
    } catch (e) {
      ScaffoldMessenger.of(context).showSnackBar(
        SnackBar(
          content: Text(context.translate(LangKeys.failedToUploadFile)),
        ),
      );
    }
  }
}
