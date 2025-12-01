import 'package:athr_hr/core/localization/lang_keys.dart';
import 'package:athr_hr/core/routes/app_routes.dart';
import 'package:athr_hr/core/styles/colors/my_colors.dart';
import 'package:athr_hr/core/styles/fonts/my_fonts.dart';
import 'package:athr_hr/core/utils/extension/my_context.dart';
import 'package:athr_hr/core/utils/validators.dart';
import 'package:athr_hr/core/widgets/custom_button.dart';
import 'package:athr_hr/core/widgets/custom_text_form_field.dart';
import 'package:athr_hr/features/auth/login/widgets/remeber_me.dart';
import 'package:athr_hr/generated/assets.dart';
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class LoginForm extends StatefulWidget {
  final GlobalKey<FormState> formKey;
  final TextEditingController emailController;
  final TextEditingController passwordController;

  const LoginForm({
    super.key,
    required this.formKey,
    required this.emailController,
    required this.passwordController,
  });

  @override
  State<LoginForm> createState() => _LoginFormState();
}

class _LoginFormState extends State<LoginForm> {
  bool isPassword = true;

  @override
  Widget build(BuildContext context) {
    return Form(
      key: widget.formKey,
      child: Column(
        children: [
          Align(
            alignment: Alignment.centerRight,
            child: Padding(
              padding: EdgeInsets.all(8.sp),
              child: Text(
                context.translate(LangKeys.email),
                style: MyFonts.styleMedium500_16.copyWith(
                  color: MyColors.black,
                ),
              ),
            ),
          ),
          Padding(
            padding: EdgeInsets.all(8.sp),
            child: CustomTextFormField(
              controller: widget.emailController,
              validator:(value)=> Validators.validateEmail(value, context),
              prefix: Image.asset(
                Assets.imagesSms,
                width: 28.w,
                height: 28.h,
                fit: BoxFit.contain,
              ),
              hintText: context.translate(LangKeys.email),
              hintStyle: MyFonts.semiBold600_16.copyWith(
                color: MyColors.jobColor,
              ),
            ),
          ),
          SizedBox(height: 10.h),
          Align(
            alignment: Alignment.centerRight,
            child: Padding(
              padding: EdgeInsets.all(8.sp),
              child: Text(
                context.translate(LangKeys.password),
                style: MyFonts.styleMedium500_16.copyWith(
                  color: MyColors.black,
                ),
              ),
            ),
          ),
          Padding(
            padding: EdgeInsets.all(8.sp),
            child: CustomTextFormField(
              isPassword: isPassword,
              controller: widget.passwordController,
              validator: (value)=> Validators.validatePassword(value, context),
              prefix: Image.asset(
                Assets.imagesPassword,
                width: 28.w,
                height: 28.h,
                fit: BoxFit.contain,
              ),
              suffix: InkWell(
                onTap: () {
                  setState(() {
                    isPassword = !isPassword;
                  });
                },
                child: Image.asset(
                  isPassword ? Assets.imagesEye : Assets.imagesEyeSlash,
                  width: 28.w,
                  height: 28.h,
                  fit: BoxFit.contain,
                ),
              ),
              hintText: context.translate(LangKeys.password),
              hintStyle: MyFonts.semiBold600_16.copyWith(
                color: MyColors.jobColor,
              ),
            ),
          ),
          SizedBox(height: 10.h),
          Padding(
            padding: EdgeInsets.all(8.sp),
            child: RememberMeWidget(onChanged: (value) {}),
          ),
          SizedBox(height: 10.h),
          SizedBox(
            width: 280.w,
            height: 54.h,
            child: CustomButton(
              txt: context.translate(LangKeys.login),
              onPressed: () {
               if(widget.formKey.currentState!.validate()){
                 Navigator.pushNamed(context, AppRoutes.mainView);
               }
              },
            ),
          ),
          SizedBox(height: 20.h),
        ],
      ),
    );
  }
}
