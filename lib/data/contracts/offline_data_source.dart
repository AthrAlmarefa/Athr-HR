import 'package:file_picker/file_picker.dart';

abstract class OfflineDataSource {
  Future<void> cacheFile(PlatformFile file);

  Future<String?> getCachedFilePath();

  Future<void> deleteCachedFile();
}
