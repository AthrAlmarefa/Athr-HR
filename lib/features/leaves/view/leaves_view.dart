import 'package:athr_hr/features/leaves/widgets/leave_request_widget.dart';
import 'package:athr_hr/features/leaves/view/create_request_view.dart';
import 'package:flutter/material.dart';

class LeavesView extends StatefulWidget {
  final ValueChanged<int>? onChangeTab;

  const LeavesView({super.key, this.onChangeTab});

   @override
   State<LeavesView> createState() => _LeavesViewState();
 }

 class _LeavesViewState extends State<LeavesView> {
   @override
   Widget build(BuildContext context) {
     return LeaveRequestWidget();
     return CreateRequestView();
   }
 }
