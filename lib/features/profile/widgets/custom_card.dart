import 'package:athr_hr/core/styles/colors/my_colors.dart';
import 'package:athr_hr/core/styles/fonts/my_fonts.dart';
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class CustomCard extends StatelessWidget {
  final String title;
  final String subtitle;
  final String iconPath;
  final double width;
  final double height;
  final Color? cardColor;
  final String? subtitleIcon;
  final String? endIcon;
  final Color? subtitleColor;
  final Color? subtitleAltColor;

  const CustomCard({
    super.key,
    required this.title,
    required this.subtitle,
    required this.iconPath,
    this.width = 398,
    this.height = 80,
    this.cardColor,
    this.subtitleIcon,
    this.endIcon,
    this.subtitleColor,
    this.subtitleAltColor,
  });

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: EdgeInsets.all(8.sp),
      child: SizedBox(
        width: width.w,
        height: height.h,
        child: Container(
          decoration: BoxDecoration(
            color: cardColor ?? MyColors.cardColor,
            borderRadius: BorderRadius.circular(8.sp),
          ),
          child: Padding(
            padding: EdgeInsets.symmetric(horizontal: 12.w),
            child: Row(
              children: [
                Image.asset(
                  iconPath,
                  width: 24.w,
                  height: 24.h,
                  fit: BoxFit.contain,
                ),
                SizedBox(width: 12.w),
                Column(
                  mainAxisAlignment: MainAxisAlignment.center,
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: [
                    Text(
                      title,
                      style: MyFonts.semiBold600_16.copyWith(
                        color: MyColors.black,
                      ),
                    ),
                    SizedBox(height: 6.h),
                    Row(
                      children: [
                        if (subtitleIcon != null) ...[
                          Image.asset(
                            subtitleIcon!,
                            width: 16.w,
                            height: 16.h,
                            fit: BoxFit.contain,
                          ),
                          SizedBox(width: 1.5.w),
                        ],
                        Text(
                          subtitle,
                          style: MyFonts.styleMedium500_11.copyWith(
                            color: subtitleColor ??
                                subtitleAltColor ??
                                MyColors.jobColor,
                          ),
                        ),
                      ],
                    ),

                  ],
                ),
                Spacer(),
                if (endIcon != null)
                  Image.asset(
                    endIcon!,
                    width: 24.w,
                    height: 24.h,
                    fit: BoxFit.contain,
                  ),
              ],
            ),
          ),
        ),
      ),
    );
  }
}
