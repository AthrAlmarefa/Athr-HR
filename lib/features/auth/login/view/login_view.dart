import 'package:athr_hr/core/localization/lang_keys.dart';
import 'package:athr_hr/core/routes/app_routes.dart';
import 'package:athr_hr/core/styles/colors/my_colors.dart';
import 'package:athr_hr/core/styles/fonts/my_fonts.dart';
import 'package:athr_hr/core/utils/extension/my_context.dart';
import 'package:athr_hr/core/widgets/custom_button.dart';
import 'package:athr_hr/core/widgets/custom_text_form_field.dart';
import 'package:athr_hr/features/auth/login/widgets/remeber_me.dart';
import 'package:athr_hr/generated/assets.dart';
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class LoginView extends StatefulWidget {
  const LoginView({super.key});

  @override
  State<LoginView> createState() => _LoginViewState();
}

class _LoginViewState extends State<LoginView> {
  bool isPassword = true;
  @override
  Widget build(BuildContext context) {
    return SafeArea(
      child: Scaffold(
        backgroundColor: MyColors.white,
        body: SingleChildScrollView(
          child: Column(
            children: [
              Align(
                alignment: Alignment.center,
                child: Padding(
                  padding: EdgeInsets.all(16.sp),
                  child: Text(
                    context.translate(LangKeys.login),
                    style: MyFonts.styleBold700_20.copyWith(
                      color: MyColors.black,
                    ),
                  ),
                ),
              ),
              SizedBox(height: 16.h),
              Image.asset(
                Assets.imagesLogo,
                width: 247.w,
                height: 175.h,
                fit: BoxFit.contain,
              ),
              SizedBox(height: 30.h),
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
                  prefix: Image.asset(
                    Assets.imagesPassword,
                    width: 28.w,
                    height: 28.h,
                    fit: BoxFit.contain,
                  ),
                  suffix: InkWell(
                    onTap: (){
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
                    Navigator.pushNamed(context, AppRoutes.mainView);
                  },
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
