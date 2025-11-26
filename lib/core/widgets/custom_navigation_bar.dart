import 'package:athr_hr/core/localization/lang_keys.dart';
import 'package:athr_hr/core/utils/extension/my_context.dart';
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';
import 'package:athr_hr/core/styles/colors/my_colors.dart';
import 'package:athr_hr/core/styles/fonts/my_fonts.dart';

class CustomBottomNavBar extends StatefulWidget {
  final int currentIndex;
  final Function(int) onTap;
  final List<String> activeIcons;
  final List<String> inactiveIcons;

  const CustomBottomNavBar({
    super.key,
    required this.currentIndex,
    required this.onTap,
    required this.activeIcons,
    required this.inactiveIcons,
  });

  @override
  State<CustomBottomNavBar> createState() => _CustomBottomNavBarState();
}

class _CustomBottomNavBarState extends State<CustomBottomNavBar> {
  late int _currentIndex;

  @override
  void initState() {
    super.initState();
    _currentIndex = widget.currentIndex;
  }

  @override
  Widget build(BuildContext context) {
    return Container(
      height: 90.h,
      decoration: BoxDecoration(
        color: MyColors.white,
        borderRadius: BorderRadius.only(
          topLeft: Radius.circular(20.r),
          topRight: Radius.circular(20.r),
        ),
        boxShadow: [
          BoxShadow(
            color: Colors.black.withOpacity(0.1),
            blurRadius: 8,
          ),
        ],
      ),
      child: Row(
        mainAxisAlignment: MainAxisAlignment.spaceAround,
        children: List.generate(widget.activeIcons.length, (index) {
          return _navItem(
            activeImagePath: widget.activeIcons[index],
            inactiveImagePath: widget.inactiveIcons[index],
            label: _getLabel(context, index),
            index: index,
          );
        }),
      ),
    );
  }

  String _getLabel(BuildContext context, int index) {
    switch (index) {
      case 0:
        return context.translate(LangKeys.home);
      case 1:
        return  context.translate(LangKeys.times);
      case 2:
        return context.translate(LangKeys.tasks);
      case 3:
        return context.translate(LangKeys.leaves);
      case 4:
        return  context.translate(LangKeys.account);
      default:
        return '';
    }
  }
  Widget gradientText({
    required String text,
    required bool isActive,
    required TextStyle style,
  }) {
    if (!isActive) {
      return Text(
        text,
        style: style.copyWith(color: const Color(0xFF99A4B3)),
      );
    }

    return ShaderMask(
      shaderCallback: (bounds) => const LinearGradient(
        colors: [
          Color(0xFF1BABB6),
          Color(0xCC005157),
        ],
        begin: Alignment.bottomCenter,
        end: Alignment.topCenter,
      ).createShader(bounds),
      child: Text(
        text,
        style: style.copyWith(color: Colors.white),
      ),
    );
  }


  Widget _navItem({
    required String activeImagePath,
    required String inactiveImagePath,
    required String label,
    required int index,
  }) {
    bool isActive = _currentIndex == index;
    return GestureDetector(
      onTap: () {
        setState(() {
          _currentIndex = index;
        });
        widget.onTap(index);
      },
      child: Column(
        mainAxisAlignment: MainAxisAlignment.center,
        children: [
          Image.asset(
            isActive ? activeImagePath : inactiveImagePath,
            height: 28.h,
            width: 28.w,
          ),
          SizedBox(height: 4.h),
          gradientText(
            text: label,
            isActive: isActive,
            style: MyFonts.semiBold600_12,
          ),
        ],
      ),
    );
  }
}
