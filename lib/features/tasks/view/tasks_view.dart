import 'package:athr_hr/features/tasks/widgets/create_request_widget.dart';
import 'package:flutter/material.dart';


class TasksView extends StatefulWidget {
   const TasksView({super.key});

   @override
   State<TasksView> createState() => _TasksViewState();
 }

 class _TasksViewState extends State<TasksView> {
   @override
   Widget build(BuildContext context) {
     return CreateRequestWidget();
   }
 }
