import 'package:athr_hr/core/styles/colors/my_colors.dart';
import 'package:athr_hr/features/leaves/widgets/leave_request_widget.dart';
import 'package:flutter/material.dart';

class LeaveRequestView extends StatefulWidget {
  final ValueChanged<int>? onChangeTab;


  const LeaveRequestView({super.key, this.onChangeTab,});

   @override
   State<LeaveRequestView> createState() => _LeaveRequestViewState();
 }

 class _LeaveRequestViewState extends State<LeaveRequestView> {
   @override
   Widget build(BuildContext context) {
     return Scaffold(
       backgroundColor: MyColors.white,
       body: LeaveRequestWidget(onChangeTab: widget.onChangeTab,),
     );
   }
 }
