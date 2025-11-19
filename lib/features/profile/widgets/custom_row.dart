import 'package:athr_hr/core/styles/colors/my_colors.dart';
import 'package:athr_hr/core/styles/fonts/my_fonts.dart';
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class CustomRow extends StatelessWidget {
  final Widget imageIcon;
  final Widget widget;
  final String text;
  final String mainText;
  final double imageHeight;
  final double imageWidth;
  final VoidCallback? onPressed;


  const CustomRow({
    super.key,
    required this.imageIcon,
    required this.widget,
    required this.text,
    required this.mainText,
    this.imageHeight = 24,
    this.imageWidth = 24,
    this.onPressed
  });

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: EdgeInsets.all(12.sp),
      child: Row(
        children: [
          SizedBox(width: 40.w, height: 40.h, child: widget),
          SizedBox(width: 16.w),
          Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            children: [
              Text(
                mainText,
                style: MyFonts.semiBold600_16.copyWith(color: MyColors.black),
              ),
              SizedBox(height: 6.h),
              Text(
                text,
                style: MyFonts.styleMedium500_11.copyWith(
                  color: MyColors.jobColor,
                ),
              ),
            ],
          ),
          Spacer(),
          InkWell(
            onTap: onPressed,
              child: SizedBox(height: imageHeight, width: imageWidth,  child: imageIcon)),
        ],
      ),
    );
  }
}
