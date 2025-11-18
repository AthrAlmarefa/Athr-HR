import 'package:athr_hr/core/styles/colors/my_colors.dart';
import 'package:athr_hr/core/styles/fonts/my_fonts.dart';
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class CustomButton extends StatelessWidget {
  const CustomButton({
    super.key,
    required this.txt,
    this.height,
    this.width,
    this.gradientColors,
    required this.onPressed,
  });

  final String txt;
  final double? height;
  final double? width;
  final List<Color>? gradientColors;
  final void Function()? onPressed;

  @override
  Widget build(BuildContext context) {
    return GestureDetector(
      onTap: onPressed,
      child: Container(
        height: height ?? 54.h,
        width: width ?? double.infinity,
        decoration: BoxDecoration(
          borderRadius: BorderRadius.circular(12.sp),
          gradient: LinearGradient(
            colors:
                gradientColors ?? const [Color(0xFF1BABB6), Color(0xFF1BABB6)],
            begin: Alignment.centerRight,
            end: Alignment.centerLeft,
          ),
          boxShadow: [
            BoxShadow(
              color: Colors.black.withOpacity(0.15),
              blurRadius: 6,
              offset: const Offset(0, 3),
            ),
          ],
        ),
        child: Center(
          child: Text(
            txt,
            style: MyFonts.semiBold600_18.copyWith(
              color: MyColors.white
            )
          ),
        ),
      ),
    );
  }
}
