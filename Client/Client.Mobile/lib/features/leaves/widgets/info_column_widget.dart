

import 'package:athr_hr/core/styles/colors/my_colors.dart';
import 'package:athr_hr/core/styles/fonts/my_fonts.dart';
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

Widget infoColumn(String label, String value) {
  return Column(
    crossAxisAlignment: CrossAxisAlignment.center,
    children: [
      Text(label, style:MyFonts.styleMedium500_14.copyWith(
        color: MyColors.navigationIconsInActiveColor,
      )),
      Padding(
        padding: EdgeInsets.all(8.sp),
        child: Text(
            value,
            style: MyFonts.semiBold600_14.copyWith(
              color: MyColors.black,
            )
        ),
      ),
    ],
  );
}