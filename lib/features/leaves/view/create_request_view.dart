import 'package:athr_hr/core/styles/colors/my_colors.dart';
import 'package:athr_hr/features/leaves/widgets/create_request_widget.dart';
import 'package:flutter/material.dart';

class CreateRequestView extends StatefulWidget {
  final ValueChanged<int>? onChangeTab;
  const CreateRequestView({super.key, this.onChangeTab,});

   @override
   State<CreateRequestView> createState() => _CreateRequestViewState();
 }

 class _CreateRequestViewState extends State<CreateRequestView> {
   @override
   Widget build(BuildContext context) {
     return SafeArea(child: Scaffold(
       backgroundColor: MyColors.backgroundColor,
       body: CreateRequestWidget(onChangeTab: widget.onChangeTab,),
     ));
   }
 }
