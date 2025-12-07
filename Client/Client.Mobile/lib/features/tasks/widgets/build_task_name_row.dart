import 'package:athr_hr/core/localization/lang_keys.dart';
import 'package:athr_hr/core/styles/colors/my_colors.dart';
import 'package:athr_hr/core/styles/fonts/my_fonts.dart';
import 'package:athr_hr/core/utils/extension/my_context.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class BuildTaskNameRow extends StatefulWidget {
   const BuildTaskNameRow({super.key});

   @override
   State<BuildTaskNameRow> createState() => _BuildTaskNameRowState();
 }

 class _BuildTaskNameRowState extends State<BuildTaskNameRow> {
   @override
   Widget build(BuildContext context) {
     return Column(
       children: [
         Align(
           alignment: Alignment.centerRight,
           child: Text(
             context.translate(LangKeys.taskName),
             style: MyFonts.styleMedium500_16.copyWith(
               color: MyColors.navigationIconsInActiveColor,
             ),
           ),
         ),
         SizedBox(height: 20.h),
         Row(
           children: [
             Text(
               context.translate(LangKeys.authenticationUnit),
               style: MyFonts.semiBold600_18.copyWith(
                 color: MyColors.black,
               ),
             ),
             Spacer(),
             Container(
               width: 70.w,
               height: 32.h,
               decoration: BoxDecoration(
                 color: MyColors.navigationIconsInActiveColor.withOpacity(0.07),
                 borderRadius: BorderRadius.circular(8.sp),
               ),
               child: Center(
                 child: Text(
                   context.translate(LangKeys.inProgress),
                   style: MyFonts.styleRegular400_12.copyWith(
                     color: MyColors.pendingTextColor,
                   ),
                 ),
               ),
             ),
           ],
         ),
       ],
     );
   }
 }
