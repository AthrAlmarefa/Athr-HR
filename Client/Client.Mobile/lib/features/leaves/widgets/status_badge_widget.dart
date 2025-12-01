import 'package:athr_hr/core/localization/lang_keys.dart';
import 'package:athr_hr/core/styles/colors/my_colors.dart';
import 'package:athr_hr/core/styles/fonts/my_fonts.dart';
import 'package:athr_hr/core/utils/extension/my_context.dart';
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

Widget statusBadge(String status, BuildContext context) {
  return Container(
    padding: EdgeInsets.symmetric(horizontal: 12.w, vertical: 6.h),
    decoration: BoxDecoration(
      color: MyColors.containerColor,
      borderRadius: BorderRadius.circular(12.sp),
    ),
    child: Text(
      status,
      style:  MyFonts.styleMedium500_12.copyWith(
        color: status == context.translate(LangKeys.approvedStatus)
            ? MyColors.green
            : MyColors.pendingTextColor,
      ),
    ),
  );
}
