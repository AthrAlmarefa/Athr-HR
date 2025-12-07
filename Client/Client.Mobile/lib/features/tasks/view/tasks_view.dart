import 'package:athr_hr/features/tasks/widgets/tasks_widget.dart';
import 'package:flutter/material.dart';


class TasksView extends StatefulWidget {
   const TasksView({super.key});

   @override
   State<TasksView> createState() => _TasksViewState();
 }

 class _TasksViewState extends State<TasksView> {
   @override
   Widget build(BuildContext context) {
     return TasksWidget();
   }
 }
