import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';
import 'package:athr_hr/core/styles/colors/my_colors.dart';
import 'package:athr_hr/core/styles/fonts/my_fonts.dart';

class BuildCustomRow extends StatelessWidget {
  final String text;
  final String imagePath;
  final VoidCallback? onTap;

  const BuildCustomRow({
    super.key,
    required this.text,
    required this.imagePath,
    this.onTap,
  });

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: EdgeInsets.all(8.sp),
      child: Row(
        mainAxisAlignment: MainAxisAlignment.spaceBetween,
        children: [
          Text(
            text,
            style: MyFonts.styleBold700_16.copyWith(
              color: MyColors.black,
            ),
          ),
          InkWell(
            onTap: onTap,
            child: Image.asset(
              imagePath,
              width: 30.w,
              height: 30.h,
              fit: BoxFit.contain,
            ),
          ),
        ],
      ),
    );
  }
}
