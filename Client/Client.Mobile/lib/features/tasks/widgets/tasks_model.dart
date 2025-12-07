class TaskModel {
  String title;
  String subtitle;
  int progress;
  String date;
  String? imagePath;
  Function(int)? onProgressChanged;

  TaskModel({
    required this.title,
    required this.subtitle,
    required this.progress,
    required this.date,
    this.imagePath,
    this.onProgressChanged,
  });
}
