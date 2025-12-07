import 'package:athr_hr/core/localization/lang_keys.dart';
import 'package:athr_hr/core/styles/colors/my_colors.dart';
import 'package:athr_hr/core/styles/fonts/my_fonts.dart';
import 'package:athr_hr/core/utils/extension/my_context.dart';
import 'package:athr_hr/generated/assets.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class BuildAssignedByRow extends StatefulWidget {
   const BuildAssignedByRow({super.key});

   @override
   State<BuildAssignedByRow> createState() => _BuildAssignedByRowState();
 }

 class _BuildAssignedByRowState extends State<BuildAssignedByRow> {
   @override
   Widget build(BuildContext context) {
     return Column(
       children: [
         Align(
           alignment: Alignment.centerRight,
           child: Text(
             context.translate(LangKeys.assignedBy),
             style: MyFonts.styleMedium500_16.copyWith(
               color: MyColors.navigationIconsInActiveColor,
             ),
           ),
         ),
         SizedBox(height: 20.h,),
         Row(
           children: [
             Image.asset(Assets.imagesAssigndbyphoto,
               width: 36.w,
               height: 36.h,
               fit: BoxFit.contain,),
             SizedBox(width: 8.w,),
             Text(
               context.translate(LangKeys.abdullahMohamed),
               style: MyFonts.styleRegular400_16.copyWith(
                 color: MyColors.black,
               ),
             ),
           ],
         ),
       ],
     );
   }
 }
