import 'package:athr_hr/core/localization/lang_keys.dart';
import 'package:athr_hr/core/styles/colors/my_colors.dart';
import 'package:athr_hr/core/styles/fonts/my_fonts.dart';
import 'package:athr_hr/core/utils/extension/my_context.dart';
import 'package:athr_hr/core/widgets/custom_app_bar_row.dart';
import 'package:athr_hr/core/widgets/custom_button.dart';
import 'package:athr_hr/core/widgets/custom_text_form_field.dart';
import 'package:athr_hr/generated/assets.dart';
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class ChangePasswordView extends StatefulWidget {
  final ValueChanged<int>? onChangeTab;

  const ChangePasswordView({super.key, this.onChangeTab});

  @override
  State<ChangePasswordView> createState() => _ChangePasswordViewState();
}

class _ChangePasswordViewState extends State<ChangePasswordView> {
  bool isCurrentPassword = true;
  bool isNewPassword = true;
  bool isNewPasswordConfirm = true;

  @override
  Widget build(BuildContext context) {
    return Container(
      color: MyColors.white,
      child: SafeArea(
        child: SingleChildScrollView(
          child: Column(
            children: [
              Padding(
                padding: EdgeInsets.all(16.sp),
                child: CustomAppBarRow(
                  title: context.translate(LangKeys.securitySettings),
                  trailing: Image.asset(
                    Assets.imagesArrow,
                    width: 24.w,
                    height: 24.h,
                    fit: BoxFit.contain,
                  ),
                  onPressed: (){
                    widget.onChangeTab?.call(4);
                  },
                ),
              ),
              SizedBox(height: 32.h),
              Image.asset(
                Assets.imagesMobile,
                width: 192.w,
                height: 140.h,
                fit: BoxFit.contain,
              ),
              SizedBox(height: 32.h),
              Padding(
                padding: EdgeInsets.all(8.sp),
                child: Align(
                  alignment: Alignment.centerRight,
                  child: Text(
                    context.translate(LangKeys.currentPassword),
                    style: MyFonts.styleMedium500_16.copyWith(
                      color: MyColors.black,
                    ),
                  ),
                ),
              ),
              Padding(
                padding: EdgeInsets.all(12.sp),
                child: CustomTextFormField(
                  isPassword: isCurrentPassword,
                  hintText: '••••••••••••••••',
                  suffix: InkWell(
                    onTap: (){
                      setState(() {
                        isCurrentPassword = !isCurrentPassword;
                      });
                    },
                    child: Image.asset(
                      isCurrentPassword ? Assets.imagesEye : Assets.imagesEyeSlash,
                      width: 20.w,
                      height: 20.h,
                      fit: BoxFit.contain,
                    ),
                  ),
                ),
              ),
              Padding(
                padding: EdgeInsets.all(8.sp),
                child: Align(
                  alignment: Alignment.centerRight,
                  child: Text(
                    context.translate(LangKeys.newPassword),
                    style: MyFonts.styleMedium500_16.copyWith(
                      color: MyColors.black,
                    ),
                  ),
                ),
              ),
              Padding(
                padding: EdgeInsets.all(12.sp),
                child: CustomTextFormField(
                  isPassword: isNewPassword,
                  hintText: '••••••••••••••••',
                  suffix: InkWell(
                    onTap: (){
                      setState(() {
                        isNewPassword = !isNewPassword;
                      });
                    },
                    child: Image.asset(
                      isNewPassword ? Assets.imagesEye : Assets.imagesEyeSlash,
                      width: 20.w,
                      height: 20.h,
                      fit: BoxFit.contain,
                    ),
                  ),
                ),
              ),
              Padding(
                padding: EdgeInsets.all(8.sp),
                child: Align(
                  alignment: Alignment.centerRight,
                  child: Text(
                    context.translate(LangKeys.confirmNewPassword),
                    style: MyFonts.styleMedium500_16.copyWith(
                      color: MyColors.black,
                    ),
                  ),
                ),
              ),
              Padding(
                padding: EdgeInsets.all(12.sp),
                child: CustomTextFormField(
                  isPassword: isNewPasswordConfirm,
                  hintText: '••••••••••••••••',
                  suffix:InkWell(
                    onTap: (){
                      setState(() {
                        isNewPasswordConfirm = !isNewPasswordConfirm;
                      });
                    },
                    child: Image.asset(
                      isNewPasswordConfirm ? Assets.imagesEye : Assets.imagesEyeSlash,
                      width: 20.w,
                      height: 20.h,
                      fit: BoxFit.contain,
                    ),
                  ),
                ),
              ),
              SizedBox(height: 48.h),
              SizedBox(
                width: 280.w,
                height: 54.h,
                child: CustomButton(
                  txt: context.translate(LangKeys.save),
                  onPressed: () {},
                ),
              ),
              SizedBox(height: 20.h),
            ],
          ),
        ),
      ),
    );
  }
}
