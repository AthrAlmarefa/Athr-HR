import 'package:athr_hr/core/localization/lang_keys.dart';
import 'package:athr_hr/core/styles/colors/my_colors.dart';
import 'package:athr_hr/core/styles/fonts/my_fonts.dart';
import 'package:athr_hr/core/utils/extension/my_context.dart';
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class BuildPercentageProgress extends StatefulWidget {
  final ValueChanged<int>? onProgressChanged;
   const BuildPercentageProgress({super.key, this.onProgressChanged});

   @override
   State<BuildPercentageProgress> createState() => _BuildPercentageProgressState();
 }

 class _BuildPercentageProgressState extends State<BuildPercentageProgress> {
   double progress = 70;
   @override
   Widget build(BuildContext context) {
     return Column(
       children: [
         SizedBox(height: 24.h),
         Align(
           alignment: Alignment.centerRight,
           child: Text(
             context.translate(LangKeys.progressPercentage),
             style: MyFonts.styleMedium500_15.copyWith(
               color: MyColors.navigationIconsInActiveColor,
             ),
           ),
         ),
         SizedBox(height: 8.h),
         Align(
           alignment: Alignment.centerLeft,
           child: Text(
             "${progress.toInt()}%",
             style: MyFonts.styleMedium500_15.copyWith(
               color: MyColors.black,
             ),
           ),
         ),
         SizedBox(height: 2.h),
         Row(
           children: [
             Expanded(
               child: Stack(
                 alignment: Alignment.center,
                 children: [
                   ClipRRect(
                     borderRadius: BorderRadius.circular(8),
                     child: LinearProgressIndicator(
                       value: progress / 100,
                       minHeight: 10,
                       backgroundColor: MyColors.progressBackgroundColor,
                       color: MyColors.activeColor,
                     ),
                   ),
                   Positioned.fill(
                     child: Opacity(
                       opacity: 0.0,
                       child: Slider(
                         value: progress,
                         min: 0,
                         max: 100,
                         onChanged: (value) {
                           setState(() {
                             progress = value;
                           });
                           if (widget.onProgressChanged != null) {
                             widget.onProgressChanged!(value.toInt());
                           }
                         },
                       ),
                     ),
                   ),
                 ],
               ),
             ),
           ],
         ),
       ],
     );
   }
 }
