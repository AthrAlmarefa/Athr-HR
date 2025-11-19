import 'package:athr_hr/core/styles/colors/my_colors.dart';
import 'package:athr_hr/core/styles/fonts/my_fonts.dart';
import 'package:athr_hr/core/widgets/custom_button.dart';
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class CustomOnboardingScreen extends StatelessWidget {
  final String title;
  final String subtitle;
  final String imageAsset;
  final String buttonText;
  final int currentIndex;
  final VoidCallback? onButtonPressed;

  const CustomOnboardingScreen({
    super.key,
    required this.title,
    required this.subtitle,
    required this.imageAsset,
    required this.buttonText,
    this.onButtonPressed,
    required this.currentIndex,
  });

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Colors.white,
      body: SafeArea(
        child: Padding(
          padding: EdgeInsets.only(top: 130.sp),
          child: Column(
            children: [
              Center(
                child: SizedBox(
                  width: 325.w,
                  height: 200.h,
                  child: Image.asset(
                    imageAsset,
                    fit: BoxFit.contain,
                  ),
                ),
              ),

              SizedBox(height: 20.h),
              _TextSection(title: title, subtitle: subtitle),
              const SizedBox(height: 30),
              const SizedBox(height: 30),
              DotsIndicator(currentIndex: currentIndex),
              const SizedBox(height: 50),
              SizedBox(
                width: 300.w,
                height: 54.h,
                child: CustomButton(
                  txt: buttonText,
                  onPressed: onButtonPressed,
                ),
              ),
              SizedBox(height: 20.h),
            ],
          ),
        ),
      ),
    );
  }
}

class DotsIndicator extends StatelessWidget {
  final int currentIndex;
  final int totalDots;

  const DotsIndicator({
    super.key,
    required this.currentIndex,
    this.totalDots = 3,
  });

  @override
  Widget build(BuildContext context) {
    return Row(
      mainAxisAlignment: MainAxisAlignment.center,
      children: List.generate(totalDots, (index) {
        return Padding(
          padding: const EdgeInsets.symmetric(horizontal: 4),
          child: _dot(index == currentIndex),
        );
      }),
    );
  }

  Widget _dot(bool active) {
    return Container(
      width: active ? 40 : 10,
      height: 10,
      decoration: BoxDecoration(
        color: active
            ? MyColors.activeColor
            : MyColors.notActiveColor.withOpacity(0.2),
        borderRadius: BorderRadius.circular(20),
      ),
    );
  }
}

class _TextSection extends StatelessWidget {
  final String title;
  final String subtitle;

  const _TextSection({required this.title, required this.subtitle});

  @override
  Widget build(BuildContext context) {
    return Column(
      crossAxisAlignment: CrossAxisAlignment.center,
      children: [
        Text(
          title,
          style: MyFonts.semiBold600_20.copyWith(color: MyColors.black),
          textAlign: TextAlign.start,
        ),
        SizedBox(height: 15.h),
        Text(
          subtitle,
          style: MyFonts.styleBold700_32.copyWith(color: MyColors.black),
        ),
      ],
    );
  }
}
