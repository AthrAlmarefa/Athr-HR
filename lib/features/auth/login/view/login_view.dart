import 'package:athr_hr/core/localization/lang_keys.dart';
import 'package:athr_hr/core/styles/colors/my_colors.dart';
import 'package:athr_hr/core/styles/fonts/my_fonts.dart';
import 'package:athr_hr/core/utils/extension/my_context.dart';
import 'package:athr_hr/features/auth/login/widgets/login_form.dart';
import 'package:athr_hr/generated/assets.dart';
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class LoginView extends StatefulWidget {
  const LoginView({super.key});

  @override
  State<LoginView> createState() => _LoginViewState();
}

class _LoginViewState extends State<LoginView> {
  dynamic passwordController;
  dynamic emailController;
  final formKey = GlobalKey<FormState>();

  @override
  void initState() {
    passwordController = TextEditingController();
    emailController = TextEditingController();
    super.initState();
  }

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
              LoginForm(
                formKey: formKey,
                emailController: emailController,
                passwordController: passwordController,
              ),
            ],
          ),
        ),
      ),
    );
  }
}
