import 'package:athr_hr/features/tasks/widgets/task_details_widget.dart';
import 'package:flutter/material.dart';

class TaskDetailsView extends StatefulWidget {
   const TaskDetailsView({super.key});

   @override
   State<TaskDetailsView> createState() => _TaskDetailsViewState();
 }

 class _TaskDetailsViewState extends State<TaskDetailsView> {
   @override
   Widget build(BuildContext context) {
     return TaskDetailsWidget();
   }
 }
