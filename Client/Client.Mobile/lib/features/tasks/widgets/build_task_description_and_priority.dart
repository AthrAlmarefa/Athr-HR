import 'package:athr_hr/core/localization/lang_keys.dart';
import 'package:athr_hr/core/styles/colors/my_colors.dart';
import 'package:athr_hr/core/styles/fonts/my_fonts.dart';
import 'package:athr_hr/core/utils/extension/my_context.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class BuildTaskDescriptionAndPriority extends StatefulWidget {
   const BuildTaskDescriptionAndPriority({super.key});

   @override
   State<BuildTaskDescriptionAndPriority> createState() => _BuildTaskDescriptionAndPriorityState();
 }

 class _BuildTaskDescriptionAndPriorityState extends State<BuildTaskDescriptionAndPriority> {
   @override
   Widget build(BuildContext context) {
     return Column(
       crossAxisAlignment: CrossAxisAlignment.start,
       children: [
         Align(
           alignment: Alignment.centerRight,
           child: Text(
             context.translate(LangKeys.taskDescription),
             style: MyFonts.styleMedium500_16.copyWith(
               color: MyColors.navigationIconsInActiveColor,
             ),
           ),
         ),
         SizedBox(height: 20.h,),
         Text(
           context.translate(LangKeys.oauthIntegration),
           style: MyFonts.semiBold600_16.copyWith(
             color: MyColors.black,
           ),
         ),
         SizedBox(height: 20.h),
         Align(
           alignment: Alignment.centerRight,
           child: Text(
             context.translate(LangKeys.priority),
             style: MyFonts.styleMedium500_16.copyWith(
               color: MyColors.navigationIconsInActiveColor,
             ),
           ),
         ),
         SizedBox(height: 20.h,),
         Text(
           context.translate(LangKeys.high),
           style: MyFonts.semiBold600_16.copyWith(
             color: MyColors.black,
           ),
         ),
       ],
     );
   }
 }
