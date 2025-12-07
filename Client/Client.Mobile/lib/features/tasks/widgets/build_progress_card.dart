import 'package:athr_hr/core/styles/colors/my_colors.dart';
import 'package:athr_hr/core/styles/fonts/my_fonts.dart';
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class BuildProgressCard extends StatelessWidget {
  final String title;
  final String subtitle;
  final String date;
  final int progress;
  final String mainImagePath;
  final String userImagePath;
  final String calendarImagePath;
  final String assignedBy;
  final String userName;
  final ValueChanged<int>? onProgressChanged;

  const BuildProgressCard({
    super.key,
    required this.title,
    required this.subtitle,
    required this.date,
    required this.progress,
    required this.mainImagePath,
    required this.userImagePath,
    required this.calendarImagePath,
    this.onProgressChanged, required this.assignedBy,
    required this.userName,
  });

  @override
  Widget build(BuildContext context) {
    return Container(
      margin: EdgeInsets.only(bottom: 14.h),
      padding: EdgeInsets.all(18.sp),
      decoration: BoxDecoration(
        color: MyColors.white,
        borderRadius: BorderRadius.circular(16.sp),
      ),
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          Row(
            children: [
              Image.asset(
                mainImagePath,
                width: 40.w,
                height: 40.h,
              ),
              SizedBox(width: 12.w),
              Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  Text(
                    title,
                    style: MyFonts.styleBold700_16.copyWith(
                      color: MyColors.black,
                    ),
                  ),
                  SizedBox(height: 6.h),
                  Text(
                    subtitle,
                    style: MyFonts.styleRegular400_14.copyWith(
                      color: MyColors.navigationIconsInActiveColor,
                    ),
                  ),
                ],
              ),
            ],
          ),
          SizedBox(height: 18.h),
          Row(
            children: [
              Expanded(
                child: Stack(
                  alignment: Alignment.center,
                  children: [
                    ClipRRect(
                      borderRadius: BorderRadius.circular(8),
                      child: LinearProgressIndicator(
                        value: progress / 100,
                        minHeight: 10,
                        backgroundColor: MyColors.progressBackgroundColor,
                        color: MyColors.activeColor,
                      ),
                    ),
                    Positioned.fill(
                      child: Opacity(
                        opacity: 0.0,
                        child: Slider(
                          value: progress.toDouble(),
                          min: 0,
                          max: 100,
                          onChanged: (value) {
                            if (onProgressChanged != null) {
                              onProgressChanged!(value.toInt());
                            }
                          },
                        ),
                      ),
                    ),
                  ],
                ),
              ),
              SizedBox(width: 12.w),
              Text(
                "$progress%",
                style: MyFonts.styleMedium500_14.copyWith(
                  color: MyColors.black,
                ),
              ),
            ],
          ),
          SizedBox(height: 26.h),
          Row(
            children: [
              Row(
                children: [
                  Image.asset(
                    userImagePath,
                    width: 16.w,
                    height: 16.h,
                    fit: BoxFit.contain,
                  ),
                  SizedBox(width: 6.w),
                  RichText(
                    text: TextSpan(
                      children: [
                        TextSpan(
                          text: assignedBy,
                          style: MyFonts.styleRegular400_10.copyWith(
                            color: MyColors.assignedByColor,
                          ),
                        ),
                        TextSpan(
                          text:userName,
                          style: MyFonts.styleRegular400_10.copyWith(
                            color: MyColors.assignedByColor,
                          ),
                        ),
                      ],
                    ),
                  ),
                ],
              ),
              Spacer(),
              Row(
                children: [
                  Image.asset(
                    calendarImagePath,
                    width: 16.w,
                    height: 16.h,
                    fit: BoxFit.contain,
                  ),
                  SizedBox(width: 6.w),
                  Text(
                    date,
                    style: MyFonts.styleRegular400_10.copyWith(
                      color: MyColors.assignedByColor,
                    ),
                  ),
                ],
              ),
            ],
          ),
        ],
      ),
    );
  }
}
