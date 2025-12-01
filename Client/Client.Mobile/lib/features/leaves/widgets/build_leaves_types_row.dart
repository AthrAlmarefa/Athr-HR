import 'package:athr_hr/core/localization/lang_keys.dart';
import 'package:athr_hr/core/styles/colors/my_colors.dart';
import 'package:athr_hr/core/styles/fonts/my_fonts.dart';
import 'package:athr_hr/core/utils/extension/my_context.dart';
import 'package:athr_hr/generated/assets.dart';
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class BuildLeavesTypesRow extends StatefulWidget {
   const BuildLeavesTypesRow({super.key});

   @override
   State<BuildLeavesTypesRow> createState() => _BuildLeavesTypesRowState();
 }

 class _BuildLeavesTypesRowState extends State<BuildLeavesTypesRow> {
   @override
   Widget build(BuildContext context) {
     return Padding(
       padding: EdgeInsets.all(8.sp),
       child: Row(
         mainAxisAlignment: MainAxisAlignment.spaceBetween,
         children: [
           Text(
             context.translate(LangKeys.leaves),
             style: MyFonts.styleBold700_16.copyWith(
               color: MyColors.black,
             ),
           ),
           InkWell(
             onTap: (){
             },
             child: Image.asset(
               Assets.imagesLeavetype,
               width: 30.w,
               height: 30.h,
               fit: BoxFit.contain,
             ),
           ),
         ],
       ),
     );
   }
 }
