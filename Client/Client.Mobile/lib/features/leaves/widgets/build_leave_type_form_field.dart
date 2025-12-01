import 'package:athr_hr/core/localization/lang_keys.dart';
import 'package:athr_hr/core/styles/colors/my_colors.dart';
import 'package:athr_hr/core/styles/fonts/my_fonts.dart';
import 'package:athr_hr/core/utils/extension/my_context.dart';
import 'package:athr_hr/core/widgets/custom_text_form_field.dart';
import 'package:athr_hr/features/leaves/widgets/build_drop_down_list.dart';
import 'package:athr_hr/features/leaves/widgets/build_pick_time.dart';
import 'package:athr_hr/generated/assets.dart';
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class BuildLeaveTypeFormField extends StatefulWidget {
   const BuildLeaveTypeFormField({super.key});

   @override
   State<BuildLeaveTypeFormField> createState() => _BuildLeaveTypeFormFieldState();
 }

 class _BuildLeaveTypeFormFieldState extends State<BuildLeaveTypeFormField> {
   late TextEditingController leaveController = TextEditingController(
     text: context.translate(LangKeys.sickLeave),
   );
   late TextEditingController leaveStartDayController = TextEditingController(
     text: context.translate(LangKeys.dateExampleMonday),
   );
   late TextEditingController leaveFinalDayController = TextEditingController(
     text: context.translate(LangKeys.dateExampleThursday),
   );
   final GlobalKey leaveTypeFieldKey = GlobalKey();
   final GlobalKey leaveStartDayKey = GlobalKey();
   final GlobalKey leaveFinalDayKey = GlobalKey();
   @override
   Widget build(BuildContext context) {
     return Column(
       children: [
         Align(
           alignment: Alignment.centerRight,
           child: Text(
             context.translate(LangKeys.leaveType),
             style: MyFonts.styleMedium500_16.copyWith(
               color: MyColors.black,
             ),
           ),
         ),
         SizedBox(height: 6.h),
         SizedBox(
           width: 398.w,
           height: 64.h,
           child: CustomTextFormField(
             key: leaveTypeFieldKey,
             controller: leaveController,
             readOnly: true,
             showCursor: false,
             textStyle: MyFonts.semiBold600_18.copyWith(
               color: MyColors.black,
             ),
             suffix: GestureDetector(
               onTap: () {
                 showLeaveDropdown(
                   context: context,
                   controller: leaveController,
                   options: [
                     context.translate(LangKeys.annualLeave),
                     context.translate(LangKeys.sickLeave),
                     context.translate(LangKeys.emergencyLeave),
                     context.translate(LangKeys.workLeave),
                     context.translate(LangKeys.permission),
                   ],
                   fieldKey: leaveTypeFieldKey,
                 );
               },
               child: Image.asset(
                 Assets.imagesDropdownarrow,
                 width: 24.w,
                 height: 24.h,
                 fit: BoxFit.contain,
               ),
             ),
           ),
         ),
         SizedBox(height: 24.h),
         Align(
           alignment: Alignment.centerRight,
           child: Text(
             context.translate(LangKeys.leaveStart),
             style: MyFonts.styleMedium500_16.copyWith(
               color: MyColors.black,
             ),
           ),
         ),
         SizedBox(height: 6.h),
         SizedBox(
           width: 398.w,
           height: 64.h,
           child: CustomTextFormField(
             controller: leaveStartDayController,
             readOnly: true,
             showCursor: false,
             key: leaveStartDayKey,
             textStyle: MyFonts.semiBold600_18.copyWith(
               color: MyColors.black,
             ),
             suffix: GestureDetector(
               onTap: () async {
                 DateTime? date = await pickDate(context: context);
                 if (date != null) {
                   leaveStartDayController.text = formatDateToArabic(
                     context,
                     date,
                   );
                 }
               },
               child: Image.asset(
                 Assets.imagesDropdownarrow,
                 width: 24.w,
                 height: 24.h,
                 fit: BoxFit.contain,
               ),
             ),
           ),
         ),
         SizedBox(height: 24.h),
         Align(
           alignment: Alignment.centerRight,
           child: Text(
             context.translate(LangKeys.leaveEnd),
             style: MyFonts.styleMedium500_16.copyWith(
               color: MyColors.black,
             ),
           ),
         ),
         SizedBox(height: 6.h),
         SizedBox(
           width: 398.w,
           height: 64.h,
           child: CustomTextFormField(
             controller: leaveFinalDayController,
             readOnly: true,
             showCursor: false,
             key: leaveFinalDayKey,
             textStyle: MyFonts.semiBold600_18.copyWith(
               color: MyColors.black,
             ),
             suffix: GestureDetector(
               onTap: () async {

                 DateTime? date = await pickDate(context: context);
                 if (date != null) {
                   leaveFinalDayController.text = formatDateToArabic(
                     context,
                     date,
                   );
                 }
               },
               child: Image.asset(
                 Assets.imagesDropdownarrow,
                 width: 24.w,
                 height: 24.h,
                 fit: BoxFit.contain,
               ),
             ),
           ),
         ),
         SizedBox(height: 24.h),
       ],
     );
   }
 }
