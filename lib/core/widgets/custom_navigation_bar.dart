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
          Text(
            label,
            style: MyFonts.semiBold600_12.copyWith(
              color: isActive
                  ? MyColors.navigationIconsActiveColor.withOpacity(0.8)
                  : MyColors.navigationIconsInActiveColor,
            ),
          ),
        ],
      ),
    );
  }
}
