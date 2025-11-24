import 'package:athr_hr/features/tasks/widgets/leave_request_widget.dart';
import 'package:flutter/material.dart';

class LeaveRequestView extends StatefulWidget {
   const LeaveRequestView({super.key});

   @override
   State<LeaveRequestView> createState() => _LeaveRequestViewState();
 }

 class _LeaveRequestViewState extends State<LeaveRequestView> {
   @override
   Widget build(BuildContext context) {
     return Scaffold(
       body: LeaveRequestWidget(),
     );
   }
 }
