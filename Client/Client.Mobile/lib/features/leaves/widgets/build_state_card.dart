import 'package:athr_hr/core/styles/colors/my_colors.dart';
import 'package:athr_hr/core/styles/fonts/my_fonts.dart';
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class SelectableStateCard extends StatelessWidget {
  final String title;
  final Color titleColor;
  final String value;
  final String iconPath;
  final Color valueContainerColor;
  final Color valueTextColor;
  final bool isSelected;
  final VoidCallback? onSelect;

  const SelectableStateCard({
    super.key,
    required this.title,
    required this.value,
    required this.iconPath,
    this.valueContainerColor = Colors.blue,
    this.valueTextColor = Colors.white,
    required this.titleColor,
    this.isSelected = false,
    this.onSelect,
  });

  @override
  Widget build(BuildContext context) {
    return GestureDetector(
      onTap: onSelect,
      child: Container(
        width: 175.w,
        height: 125.h,
        padding: EdgeInsets.all(10.sp),
        decoration: BoxDecoration(
          color: MyColors.white,
          gradient: isSelected
              ? const LinearGradient(
            colors: [
              Color(0xFF1BABB6),
              Color(0xCC005157),
            ],
            begin: Alignment.topCenter,
            end: Alignment.bottomCenter,
          )
              : null,
          borderRadius: BorderRadius.circular(12.sp),
        ),
        child: Column(
          children: [
            Image.asset(
              iconPath,
              width: 32,
              height: 32,
              fit: BoxFit.contain,
            ),
            SizedBox(height: 4.h),
            Text(
              title,
              style: MyFonts.semiBold600_14.copyWith(
                color: (isSelected) ? titleColor : MyColors.black,
              ),
            ),
            SizedBox(height: 6.h),
            Container(
              width: 28.w,
              height: 29.h,
              alignment: Alignment.center,
              decoration: BoxDecoration(
                color: valueContainerColor,
                borderRadius: BorderRadius.circular(6.sp),
              ),
              child: Text(
                value,
                style: MyFonts.semiBold600_16.copyWith(
                  color: (isSelected) ? valueTextColor : MyColors.green,
                ),
              ),
            ),
          ],
        ),
      ),
    );
  }
}
