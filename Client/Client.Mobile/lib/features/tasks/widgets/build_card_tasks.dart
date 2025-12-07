import 'package:athr_hr/core/localization/lang_keys.dart';
import 'package:athr_hr/core/styles/colors/my_colors.dart';
import 'package:athr_hr/core/styles/fonts/my_fonts.dart';
import 'package:athr_hr/core/utils/extension/my_context.dart';
import 'package:athr_hr/generated/assets.dart';
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class BuildCardTasksSelectable extends StatefulWidget {
  const BuildCardTasksSelectable({super.key});

  @override
  State<BuildCardTasksSelectable> createState() => BuildCardTasksSelectableState();
}

class BuildCardTasksSelectableState extends State<BuildCardTasksSelectable> {
  int selectedIndex = 0;

  late final List<String> titles = [
    context.translate(LangKeys.totalTasks),
    context.translate(LangKeys.completed),
    context.translate(LangKeys.inProgress),
  ];

  late final List<String> values = [
    context.translate(LangKeys.allTasksValue),
    context.translate(LangKeys.pendingValue),
    context.translate(LangKeys.approvedValue),
  ];

  final List<String> icons = [
    Assets.imagesTotaltasks,
    Assets.imagesCompleted,
    Assets.imagesUnderimplementationblue,
  ];

  final List<Size> valueContainerSizes = [
    const Size(44, 44),
    const Size(28, 29),
    const Size(28, 29),
  ];

  final List<Color> valueTextColors = [
    MyColors.white.withOpacity(0.7),
    MyColors.green,
    MyColors.blueColor,
  ];

  @override
  Widget build(BuildContext context) {
    return Row(
      mainAxisAlignment: MainAxisAlignment.center,
      children: [
        buildSingleContainer(0, width: 150.w, height: 268.h),
        SizedBox(width: 10.w),
        Column(
          children: [
            buildSingleContainer(2, width: 185.w, height: 130.h),
            SizedBox(height: 8.h),
            buildSingleContainer(1, width: 185.w, height: 130.h),
          ],
        ),
      ],
    );
  }

  Widget buildSingleContainer(int index, {required double width, required double height}) {
    bool isSelected = selectedIndex == index;
    Color? iconColor;
    if (index == 0 && !isSelected) {
      iconColor = Colors.black;
    }
    Color valueTextColor = isSelected
        ? Colors.white
        : (index == 0 ? Colors.black : valueTextColors[index]);

    return GestureDetector(
      onTap: () {
        setState(() {
          selectedIndex = index;
        });
      },
      child: Container(
        width: width,
        height: height,
        padding: EdgeInsets.all(8.sp),
        decoration: BoxDecoration(
          color: MyColors.white,
          gradient: isSelected
              ? const LinearGradient(
            colors: [Color(0xFF1BABB6), Color(0xCC005157)],
            begin: Alignment.topCenter,
            end: Alignment.bottomCenter,
          )
              : null,
          borderRadius: BorderRadius.circular(12.sp),
        ),
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            Image.asset(
              icons[index],
              width: 24.w,
              height: 24.h,
              fit: BoxFit.contain,
              color: iconColor,
            ),
            SizedBox(height: 4.h),
            Text(
              titles[index],
              style: MyFonts.semiBold600_14.copyWith(
                color: isSelected ? Colors.white : MyColors.black,
              ),
            ),
            SizedBox(height: 24.h),
            Container(
              width: valueContainerSizes[index].width.w,
              height: valueContainerSizes[index].height.h,
              alignment: Alignment.center,
              decoration: BoxDecoration(
                color: MyColors.containerColor,
                borderRadius: BorderRadius.circular(6.sp),
              ),
              child: Text(
                values[index],
                style: MyFonts.semiBold600_16.copyWith(
                  color: valueTextColor,
                ),
              ),
            ),
          ],
        ),
      ),
    );
  }
}
