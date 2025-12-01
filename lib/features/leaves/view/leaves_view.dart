import 'package:athr_hr/features/leaves/view/create_request_view.dart';
import 'package:flutter/material.dart';

class LeavesView extends StatefulWidget {
   const LeavesView({super.key});

   @override
   State<LeavesView> createState() => _LeavesViewState();
 }

 class _LeavesViewState extends State<LeavesView> {
   @override
   Widget build(BuildContext context) {
     return CreateRequestView();
   }
 }
