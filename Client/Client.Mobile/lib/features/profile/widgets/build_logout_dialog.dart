import 'package:athr_hr/core/routes/app_routes.dart';
import 'package:athr_hr/core/styles/colors/my_colors.dart';
import 'package:athr_hr/core/styles/fonts/my_fonts.dart';
import 'package:athr_hr/core/utils/extension/my_context.dart';
import 'package:athr_hr/core/utils/extension/navigation.dart';
import 'package:athr_hr/features/profile/widgets/custom_elevated_button.dart';
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';
import '../../../../../core/localization/lang_keys.dart';

void showLogoutDialog(BuildContext context) {
  showDialog(
    context: context,
    barrierDismissible: false,
    builder: (context) {
      return Center(
        child: SizedBox(
          width: 800.w,
          height: 250.h,
          child: AlertDialog(
            content: Column(
              crossAxisAlignment: CrossAxisAlignment.center,
              children: [
                SizedBox(height: 4.h),
                Text(
                  context.translate(LangKeys.logout),
                  style: MyFonts.styleBold700_20.copyWith(
                    color: MyColors.deleteColor,
                  ),
                ),
                SizedBox(height: 22.h),
                Text(
                  context.translate(LangKeys.logoutConfirmation),
                  style: MyFonts.styleRegular400_14.copyWith(
                    color: MyColors.black,
                  ),
                ),
                SizedBox(height: 22.h),
                Row(
                  children: [
                    Expanded(
                      child: CustomElevatedButton(
                        text: context.translate(LangKeys.cancel),
                        width: 80.w,
                        height: 36.h,
                        backgroundColor: MyColors.deleteColor,
                        textColor: MyColors.white,
                        borderRadius: 100.r,
                        onPressed: () {
                          Navigator.of(context).pop();
                        },
                      ),
                    ),
                    SizedBox(width: 10.w),
                    Expanded(
                      child: CustomElevatedButton(
                        text: context.translate(LangKeys.confirmExit),
                        width: 80.w,
                        height: 36.h,
                        backgroundColor: MyColors.confirmLogoutColor,
                        textColor: MyColors.black,
                        borderRadius: 100.r,
                        onPressed: () {
                          context.pushReplacementNamed(AppRoutes.login);
                        },
                      ),
                    ),
                  ],
                ),

              ],
            ),
          ),
        ),
      );
    },
  );
}
