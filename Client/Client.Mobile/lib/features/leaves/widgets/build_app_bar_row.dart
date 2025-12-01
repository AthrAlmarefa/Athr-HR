import 'package:athr_hr/core/styles/colors/my_colors.dart';
import 'package:athr_hr/core/styles/fonts/my_fonts.dart';
import 'package:athr_hr/generated/assets.dart';
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class BuildRow extends StatelessWidget {
  final String titleKey;
  final String? iconPath;
  final VoidCallback? onPressed;
  final String image;

  const BuildRow({
    super.key,
    required this.titleKey,
    this.iconPath,
    this.onPressed,
    required this.image,
  });

  @override
  Widget build(BuildContext context) {
    return Row(
      children: [
        GestureDetector(
          child: Image.asset(
            iconPath ?? Assets.imagesRightArrow,
            width: 24.w,
            height: 24.h,
            fit: BoxFit.contain,
          ),
        ),
        SizedBox(width: 8.w),
        Text(
          titleKey,
          style: MyFonts.styleBold700_20.copyWith(
            color: MyColors.black,
          ),
        ),
        Spacer(),
        InkWell(
          onTap: onPressed,
          child: Image.asset(
            image,
            width: 118.w,
            height: 32.h,
            fit: BoxFit.contain,
          ),
        ),
      ],
    );
  }
}
