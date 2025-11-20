import 'package:athr_hr/core/localization/lang_keys.dart';
import 'package:athr_hr/core/styles/colors/my_colors.dart';
import 'package:athr_hr/core/styles/fonts/my_fonts.dart';
import 'package:athr_hr/core/utils/extension/my_context.dart';
import 'package:athr_hr/features/profile/widgets/custom_profile_data.dart';
import 'package:athr_hr/features/profile/widgets/custom_row.dart';
import 'package:athr_hr/features/profile/widgets/custom_switch_icon.dart';
import 'package:athr_hr/generated/assets.dart';
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class ProfileWidget extends StatefulWidget {
  final ValueChanged<int>? onChangeTab;
   const ProfileWidget({super.key, this.onChangeTab});

   @override
   State<ProfileWidget> createState() => _ProfileWidgetState();
 }

 class _ProfileWidgetState extends State<ProfileWidget> {
   @override
   Widget build(BuildContext context) {
     return Expanded(
       child: SingleChildScrollView(
         child: Column(
           children: [
             CustomProfileData(
               imageUrl: Assets.imagesProfile,
               name: context.translate(LangKeys.name),
               jobDescription: context.translate(LangKeys.job),
               id: context.translate(LangKeys.id),
               prefix: context.translate(LangKeys.prefix),
             ),
             CustomRow(
               imageIcon: Image.asset(Assets.imagesArrowIcon),
               widget: Image.asset(Assets.imagesProfileIcon),
               mainText: context.translate(LangKeys.personalData),
               text: '',
               imageWidth: 24.w,
               imageHeight: 24.h,
               onPressed: () {
                 widget.onChangeTab?.call(6);
               },
             ),
             CustomRow(
               imageIcon: Image.asset(Assets.imagesArrowIcon),
               widget: Image.asset(Assets.imagesLeavesIcon),
               text: context.translate(LangKeys.trackLeaveBalance),
               mainText: context.translate(LangKeys.leaveBalance),
               imageWidth: 24.w,
               imageHeight: 24.h,
             ),
             CustomRow(
               imageIcon: CustomSwitch(
                 value: true,
                 onChanged: (bool value) {},
               ),
               widget: Image.asset(Assets.imagesNotifications),
               text: context.translate(LangKeys.controlAppNotifications),
               mainText: context.translate(LangKeys.notifications),
               imageHeight: 34.h,
               imageWidth: 52.w,
             ),
             CustomRow(
               imageIcon: Image.asset(Assets.imagesArrowIcon),
               widget: Image.asset(Assets.imagesLock),
               text: context.translate(LangKeys.changeAccountPassword),
               mainText: context.translate(LangKeys.securitySettings),
               imageWidth: 24.w,
               imageHeight: 24.h,
               onPressed: () {
                 widget.onChangeTab?.call(5);
               },
             ),
             CustomRow(
               imageIcon: CustomSwitch(
                 value: true,
                 onChanged: (bool value) {},
               ),
               widget: Image.asset(Assets.imagesExistance),
               text: context.translate(
                 LangKeys.autoAttendanceDescription,
               ),
               mainText: context.translate(LangKeys.autoAttendance),
               imageHeight: 34.h,
               imageWidth: 52.w,
             ),
             CustomRow(
               imageIcon: Text(
                 context.translate(LangKeys.english),
                 style: MyFonts.styleMedium500_16.copyWith(
                   color: MyColors.black,
                 ),
               ),
               imageWidth: 60.w,
               imageHeight: 30.h,
               widget: Image.asset(Assets.imagesLanguage),
               text: context.translate(LangKeys.changeLanguageToEnglish),
               mainText: context.translate(LangKeys.language),
             ),
             SizedBox(height: 30.h),
           ],
         ),
       ),
     );
   }
 }
