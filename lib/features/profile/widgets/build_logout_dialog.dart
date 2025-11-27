import 'package:athr_hr/core/routes/app_routes.dart';
import 'package:athr_hr/core/styles/colors/my_colors.dart';
import 'package:athr_hr/core/styles/fonts/my_fonts.dart';
import 'package:athr_hr/core/utils/extension/my_context.dart';
import 'package:athr_hr/core/utils/extension/navigation.dart';
import 'package:athr_hr/core/widgets/custom_button.dart';
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
            height: 230.h,
            child: AlertDialog(
              content: Column(
                children: [
                  SizedBox(height: 4.h,),
                  Text(
                    context.translate(LangKeys.logout),
                    style: MyFonts.semiBold600_18.copyWith(
                      color: MyColors.black,
                    ),
                  ),
                  SizedBox(
                    height: 22.h,
                  ),
                  Row(
                    mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                    children: [
                      SizedBox(
                        width: 115.w,
                        height: 55.h,
                        child: CustomButton(
                          onPressed: () {
                            Navigator.pop(context);
                          },
                          txt: context.translate(LangKeys.cancel),
                        ),
                      ),
                      SizedBox(width: 10.w,),
                      SizedBox(
                        width: 115.w,
                        height: 55.h,
                        child: CustomButton(
                           txt:  context.translate(LangKeys.confirmExit), onPressed: () {
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
      });
}