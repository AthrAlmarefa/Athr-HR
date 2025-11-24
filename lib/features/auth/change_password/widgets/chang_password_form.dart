import 'package:athr_hr/core/localization/lang_keys.dart';
import 'package:athr_hr/core/routes/app_routes.dart';
import 'package:athr_hr/core/utils/extension/my_context.dart';
import 'package:athr_hr/core/styles/colors/my_colors.dart';
import 'package:athr_hr/core/styles/fonts/my_fonts.dart';
import 'package:athr_hr/core/utils/validators.dart';
import 'package:athr_hr/core/widgets/custom_button.dart';
import 'package:athr_hr/core/widgets/custom_text_form_field.dart';
import 'package:athr_hr/generated/assets.dart';
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class ChangePasswordForm extends StatefulWidget {
  final GlobalKey<FormState> formKey;
  final TextEditingController newPasswordController;
  final TextEditingController passwordController;
  final TextEditingController confirmNewPasswordController;
  final ValueChanged<int>? onChangeTab;

  const ChangePasswordForm({
    super.key,
    required this.formKey,
    required this.newPasswordController,
    required this.passwordController,
    required this.confirmNewPasswordController,
    this.onChangeTab,
  });

  @override
  State<ChangePasswordForm> createState() => _ChangePasswordFormState();
}

class _ChangePasswordFormState extends State<ChangePasswordForm> {
  bool isCurrentPassword = true;
  bool isNewPassword = true;
  bool isNewPasswordConfirm = true;

  @override
  Widget build(BuildContext context) {
    return Form(
      key: widget.formKey,
      child: Padding(
        padding: EdgeInsets.all(16.sp),
        child: Column(
          children: [
            Align(
              alignment: Alignment.centerRight,
              child: Text(
                context.translate(LangKeys.currentPassword),
                style: MyFonts.styleMedium500_16.copyWith(
                  color: MyColors.black,
                ),
              ),
            ),
            SizedBox(height: 10.h,),
            CustomTextFormField(
              validator: (value) {
                if (value == null || value.isEmpty) {
                  return context.translate(LangKeys.isRequired);
                }
                return null;
              },
              controller: widget.passwordController,
              isPassword: isCurrentPassword,
              hintText: context.translate(LangKeys.currentPassword),
              suffix: InkWell(
                onTap: () {
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
            SizedBox(height: 10.h,),
            Align(
              alignment: Alignment.centerRight,
              child: Text(
                context.translate(LangKeys.newPassword),
                style: MyFonts.styleMedium500_16.copyWith(
                  color: MyColors.black,
                ),
              ),
            ),
            SizedBox(height: 10.h,),
            CustomTextFormField(
              validator: (value) => Validators.validatePassword(value, context),
              controller: widget.newPasswordController,
              isPassword: isNewPassword,
              hintText: context.translate(LangKeys.newPassword),
              suffix: InkWell(
                onTap: () {
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
            SizedBox(height: 10.h,),
            Align(
              alignment: Alignment.centerRight,
              child: Text(
                context.translate(LangKeys.confirmNewPassword),
                style: MyFonts.styleMedium500_16.copyWith(
                  color: MyColors.black,
                ),
              ),
            ),
            SizedBox(height: 10.h,),
            CustomTextFormField(
              validator: (value) => Validators.validatePasswordConfirmation(
                password: widget.newPasswordController.text,
                confirmPassword: value,
                context: context,
              ),
              controller: widget.confirmNewPasswordController,
              isPassword: isNewPasswordConfirm,
              hintText: context.translate(LangKeys.confirmNewPassword),
              suffix: InkWell(
                onTap: () {
                  setState(() {
                    isNewPasswordConfirm = !isNewPasswordConfirm;
                  });
                },
                child: Image.asset(
                  isNewPasswordConfirm
                      ? Assets.imagesEye
                      : Assets.imagesEyeSlash,
                  width: 20.w,
                  height: 20.h,
                  fit: BoxFit.contain,
                ),
              ),
            ),
            SizedBox(height: 10.h,),
            SizedBox(height: 24.h),
            SizedBox(
              width: 280.w,
              height: 54.h,
              child: CustomButton(
                txt: context.translate(LangKeys.save),
                onPressed: () {
                  if(widget.formKey.currentState!.validate()){
                    Navigator.pushNamed(context, AppRoutes.profile);
                  }
                },
              ),
            ),
            SizedBox(height: 20.h),
          ],
        ),
      ),
    );
  }
}
