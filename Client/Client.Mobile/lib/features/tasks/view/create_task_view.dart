import 'package:athr_hr/features/tasks/widgets/create_task_widget.dart';
import 'package:flutter/material.dart';

class CreateTaskView extends StatefulWidget {
   const CreateTaskView({super.key});

   @override
   State<CreateTaskView> createState() => _CreateTaskViewState();
 }

 class _CreateTaskViewState extends State<CreateTaskView> {


   @override
   Widget build(BuildContext context) {
     return SafeArea(
         child: Scaffold(
             body: CreateTaskWidget()
         ),
     );
   }
 }
