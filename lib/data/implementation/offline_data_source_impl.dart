import 'dart:io';
import 'package:athr_hr/data/contracts/offline_data_source.dart';
import 'package:path_provider/path_provider.dart';
import 'package:shared_preferences/shared_preferences.dart';
import 'package:file_picker/file_picker.dart';

class OfflineDataSourceImpl implements OfflineFileDataSource {
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
      print("Error caching file: $e");
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
}
