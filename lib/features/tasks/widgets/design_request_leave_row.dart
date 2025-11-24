import 'package:athr_hr/core/styles/colors/my_colors.dart';
import 'package:athr_hr/core/styles/fonts/my_fonts.dart';
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class RequestLeaveRow extends StatelessWidget {
  final String rightImage;
  final String leftImage;
  final String text;
  final VoidCallback? onPressed;


  const RequestLeaveRow({
    super.key,
    required this.rightImage,
    required this.leftImage,
    required this.text,
    this.onPressed,
  });

  @override
  Widget build(BuildContext context) {
    return Container(
      padding: EdgeInsets.symmetric(vertical: 12.h, horizontal: 16.w),
      decoration: BoxDecoration(
        color: Colors.white,
        borderRadius: BorderRadius.circular(12.sp),
      ),
      child: Row(
        children: [
          Image.asset(
            rightImage,
            width: 40.w,
            height: 40.h,
          ),
          SizedBox(width: 10.w),
          Expanded(
            child: Text(
              text,
              style: MyFonts.semiBold600_16.copyWith(
                color: MyColors.black,
              ),
              textAlign: TextAlign.right,
            ),
          ),
          SizedBox(width: 10.w),
          InkWell(
            onTap: onPressed,
            child: Image.asset(
              leftImage,
              width: 28,
              height: 28,
            ),
          ),
        ],
      ),
    );
  }
}
