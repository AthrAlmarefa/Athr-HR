import 'package:athr_hr/core/localization/lang_keys.dart';
import 'package:athr_hr/core/styles/colors/my_colors.dart';
import 'package:athr_hr/core/utils/extension/my_context.dart';
import 'package:athr_hr/core/widgets/custom_app_bar_row.dart';
import 'package:athr_hr/features/auth/change_password/widgets/chang_password_form.dart';
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
  dynamic passwordController;
  dynamic newPasswordController;
  dynamic confirmNewPasswordController;
  final formKey = GlobalKey<FormState>();

  @override
  void initState() {
    passwordController = TextEditingController();
    newPasswordController = TextEditingController();
    confirmNewPasswordController = TextEditingController();
    super.initState();
  }

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
                  onPressed: () {
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
              ChangePasswordForm(
                formKey: formKey,
                passwordController: passwordController,
                newPasswordController: newPasswordController,
                confirmNewPasswordController: confirmNewPasswordController,
                onChangeTab: widget.onChangeTab,
              ),
            ],
          ),
        ),
      ),
    );
  }
}
