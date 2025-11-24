import 'package:athr_hr/core/localization/lang_keys.dart';
import 'package:athr_hr/core/styles/colors/my_colors.dart';
import 'package:athr_hr/core/styles/fonts/my_fonts.dart';
import 'package:athr_hr/core/utils/extension/my_context.dart';
import 'package:athr_hr/core/widgets/custom_app_bar_row.dart';
import 'package:athr_hr/core/widgets/custom_text_form_field.dart';
import 'package:athr_hr/features/tasks/widgets/build_drop_down_list.dart';
import 'package:athr_hr/features/tasks/widgets/build_pick_time.dart';
import 'package:athr_hr/generated/assets.dart';
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class LeaveRequestWidget extends StatefulWidget {
  const LeaveRequestWidget({super.key});

  @override
  State<LeaveRequestWidget> createState() => _LeaveRequestWidgetState();
}

class _LeaveRequestWidgetState extends State<LeaveRequestWidget> {
  late TextEditingController leaveController =
  TextEditingController(text:context.translate(LangKeys.sickLeave) );
  late TextEditingController leaveStartDayController =
  TextEditingController(text:context.translate(LangKeys.dateExampleMonday) );
  late TextEditingController leaveFinalDayController =
  TextEditingController(text:context.translate(LangKeys.dateExampleThursday) );
   late TextEditingController textController =
  TextEditingController();
  final GlobalKey leaveTypeFieldKey = GlobalKey();
  final GlobalKey leaveStartDayKey = GlobalKey();
  final GlobalKey leaveFinalDayKey = GlobalKey();
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: MyColors.white,
      body: SafeArea(child: SingleChildScrollView(
        child: Padding(
          padding: EdgeInsets.all(16.sp),
          child: Column(
            children: [
              SizedBox(height: 10.h,),
              CustomAppBarRow(
                title: context.translate(LangKeys.createRequest),
                trailing: Image.asset(
                  Assets.imagesArrow,
                  width: 24.w,
                  height: 24.h,
                  fit: BoxFit.contain,
                ),
              ),
              SizedBox(height: 36.h),
              Align(
                alignment: Alignment.centerRight,
                child: Text(
                  context.translate(LangKeys.leaveType),
                  style: MyFonts.styleBold700_18.copyWith(
                    color: MyColors.black,
                  ),
                ),
              ),
              SizedBox(height: 6.h,),
              SizedBox(
                width: 398.w,
                height: 64.h,
                child: CustomTextFormField(
                            key: leaveTypeFieldKey,
                            controller: leaveController,
                            textStyle: MyFonts.semiBold600_18.copyWith(
                color: MyColors.black,),
                            suffix: GestureDetector(
                onTap: ()  {
                  showLeaveDropdown(
                      context: context,
                      controller: leaveController,
                      options: [
                    context.translate(LangKeys.familyLeave),
                    context.translate(LangKeys.annualLeave),
                    context.translate(LangKeys.sickLeave),
                    context.translate(LangKeys.emergencyLeave)
                  ], fieldKey: leaveTypeFieldKey);
                },
                child: Image.asset(Assets.imagesDropdownarrow,
                  width: 24.w,
                  height: 24.h,
                  fit: BoxFit.contain,
                ),
                            ),
                            ),
              ),
              SizedBox(height: 24.h,),
              Align(
                alignment: Alignment.centerRight,
                child: Text(
                  context.translate(LangKeys.leaveStart),
                  style: MyFonts.styleBold700_18.copyWith(
                    color: MyColors.black,
                  ),
                ),
              ),
              SizedBox(height: 6.h,),
              SizedBox(
                width: 398.w,
                height: 64.h,
                child: CustomTextFormField(
                  controller: leaveStartDayController,
                  key: leaveStartDayKey,
                  textStyle: MyFonts.semiBold600_18.copyWith(
                    color: MyColors.black,),
                  suffix: GestureDetector(
                    onTap: () async {
                      DateTime? date = await pickDate(context: context);
                      if (date != null) {
                        leaveStartDayController.text = formatDateToArabic(context, date);
                      }
                    },
                    child: Image.asset(Assets.imagesDropdownarrow,
                      width: 24.w,
                      height: 24.h,
                      fit: BoxFit.contain,
                    ),
                  ),
                ),
              ),
              SizedBox(height: 24.h,),
              Align(
                alignment: Alignment.centerRight,
                child: Text(
                  context.translate(LangKeys.leaveEnd),
                  style: MyFonts.styleBold700_18.copyWith(
                    color: MyColors.black,
                  ),
                ),
              ),
              SizedBox(height: 6.h,),
              SizedBox(
                width: 398.w,
                height: 64.h,
                child: CustomTextFormField(
                  controller: leaveFinalDayController,
                  key: leaveFinalDayKey,
                  textStyle: MyFonts.semiBold600_18.copyWith(
                    color: MyColors.black,),
                  suffix: GestureDetector(
                    onTap: () async {
                      DateTime? date = await pickDate(context: context);
                      if (date != null) {
                        leaveFinalDayController.text = formatDateToArabic(context, date);
                      }
                    },
                    child: Image.asset(Assets.imagesDropdownarrow,
                      width: 24.w,
                      height: 24.h,
                      fit: BoxFit.contain,
                    ),
                  ),
                ),
              ),
              SizedBox(height: 24.h,),
              Align(
                alignment: Alignment.centerRight,
                child: Text(
                  context.translate(LangKeys.noteOptional),
                  style: MyFonts.styleBold700_18.copyWith(
                    color: MyColors.black,
                  ),
                ),
              ),
              SizedBox(height: 6.h,),
              SizedBox(
                width: 398.w,
                height: 200.h,
                child: CustomTextFormField(
                  controller: textController,
                  prefix: Text(context.translate(LangKeys.generalNote),
                    style: MyFonts.semiBold600_18.copyWith(
                      color: MyColors.black,),
                ),
                  maxLines: null,
                  expands: true,
                //  textAlignVertical: TextAlignVertical.top,
              ),
              ),
            ],
          ),
        ),
      )),
    );
  }
}
