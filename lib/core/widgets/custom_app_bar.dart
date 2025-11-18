import 'package:athr_hr/core/styles/colors/my_colors.dart';
import 'package:athr_hr/core/styles/fonts/my_fonts.dart';
import 'package:athr_hr/generated/assets.dart';
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';
AppBar customAppBar({
  required String appBarTxt,
  bool showArrow = false,
  VoidCallback? navigation,
  required BuildContext context,
  List<Widget>? actions,
}) {
  return AppBar(
    backgroundColor: MyColors.white,
    automaticallyImplyLeading: false,
    centerTitle: true,
    shadowColor: Colors.transparent,
    title: Text(
      appBarTxt,
      style: MyFonts.styleBold700_20,
      textAlign: TextAlign.center,
    ),
    elevation: 0.0,
    actions: showArrow
        ? [
      GestureDetector(
        onTap: () {
          if (navigation != null) {
            navigation();
          } else {
            Navigator.pop(context);
          }
        },
        child: Padding(
          padding: EdgeInsets.only(right: 16.w),
          child: Image.asset(
            Assets.imagesArrow,
            width: 24.w,
            height: 24.h,
          ),
        ),
      )
    ]
        : actions,
  );
}
