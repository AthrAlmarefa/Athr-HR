import 'package:athr_hr/core/localization/lang_keys.dart';
import 'package:athr_hr/core/styles/colors/my_colors.dart';
import 'package:athr_hr/core/utils/extension/my_context.dart';
import 'package:athr_hr/features/leaves/widgets/build_state_card.dart';
import 'package:athr_hr/generated/assets.dart';
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class StateLeavesColumn extends StatefulWidget {
  const StateLeavesColumn({super.key});

  @override
  State<StateLeavesColumn> createState() => _StateLeavesColumnState();
}

class _StateLeavesColumnState extends State<StateLeavesColumn> {
  int selectedIndex = 0;
  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        Row(
          mainAxisAlignment: MainAxisAlignment.start,
          children: [
            SelectableStateCard(title: context.translate(LangKeys.totalAnnual),
              value: context.translate(LangKeys.totalAnnualValue),
              iconPath: Assets.imagesAnnualall,
              titleColor: MyColors.white,
              valueTextColor: MyColors.white,
              valueContainerColor: MyColors.containerColor.withOpacity(0.1),
              isSelected: selectedIndex == 0,
              onSelect: () {
                setState(() => selectedIndex = 0);
              },
            ),
            SizedBox(width: 6.w),
            SelectableStateCard(title: context.translate(LangKeys.remaining),
              value: context.translate(LangKeys.remainingValue),
              iconPath: Assets.imagesRemain,
              titleColor: MyColors.black,
              valueTextColor: MyColors.green,
              valueContainerColor: MyColors.containerColor.withOpacity(0.1),
              isSelected: selectedIndex == 1,
              onSelect: () {
                setState(() => selectedIndex = 1);
              },
            ),
          ],
        ),
        SizedBox(height: 8.h,),
        Row(
          mainAxisAlignment: MainAxisAlignment.start,
          children: [
            SelectableStateCard(title: context.translate(LangKeys.pending),
              value: context.translate(LangKeys.pendingValue),
              iconPath: Assets.imagesPending,
              titleColor: MyColors.black,
              valueTextColor: MyColors.pendingTextColor,
              valueContainerColor: MyColors.containerColor.withOpacity(0.1),
              isSelected: selectedIndex == 2,
              onSelect: () {
                setState(() => selectedIndex = 2);
              },
            ),
            SizedBox(width: 6.w),
            SelectableStateCard(title: context.translate(LangKeys.used),
              value: context.translate(LangKeys.approvedValue),
              iconPath: Assets.imagesUsed,
              titleColor: MyColors.black,
              valueTextColor: MyColors.usedTextColor,
              valueContainerColor: MyColors.containerColor.withOpacity(0.1),
              isSelected: selectedIndex == 3,
              onSelect: () {
                setState(() => selectedIndex = 3);
              },
            ),
          ],
        ),
      ],
    );
  }
}
