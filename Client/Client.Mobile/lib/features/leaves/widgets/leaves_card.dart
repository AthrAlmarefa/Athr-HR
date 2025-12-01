import 'package:athr_hr/core/localization/lang_keys.dart';
import 'package:athr_hr/core/styles/colors/my_colors.dart';
import 'package:athr_hr/core/styles/fonts/my_fonts.dart';
import 'package:athr_hr/core/utils/extension/my_context.dart';
import 'package:athr_hr/features/leaves/widgets/info_column_widget.dart';
import 'package:athr_hr/features/leaves/widgets/status_badge_widget.dart';
import 'package:athr_hr/generated/assets.dart';
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class LeaveCard extends StatelessWidget {
  final String status;
  final String leaveType;
  final String duration;
  final String fromDate;
  final String toDate;

  const LeaveCard({
    super.key,
    required this.status,
    required this.leaveType,
    required this.duration,
    required this.fromDate,
    required this.toDate,
  });

  @override
  Widget build(BuildContext context) {
    return Container(
      padding: EdgeInsets.all(16.sp),
      width: 398.w,
      decoration: BoxDecoration(
        color: MyColors.white,
        borderRadius: BorderRadius.circular(16.sp),
      ),
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          Row(
            children: [
              Row(
                children: [
                  Image.asset(
                    status == context.translate(LangKeys.pendingStatus)
                        ? Assets.imagesOrangedot
                        : Assets.imagesGreendot,
                    width: 8.w,
                    height: 8.h,
                    fit: BoxFit.contain,
                  ),
                  SizedBox(width: 4.w),
                  Text(
                    leaveType,
                    style: MyFonts.semiBold600_16.copyWith(
                      color: MyColors.black,
                    ),
                  ),
                ],
              ),
              Spacer(),
              statusBadge(status, context),
            ],
          ),
          SizedBox(height: 10.h),
          Row(
            mainAxisAlignment: MainAxisAlignment.spaceBetween,
            children: [
              infoColumn(context.translate(LangKeys.duration), duration),
              infoColumn(context.translate(LangKeys.from), fromDate),
              infoColumn(context.translate(LangKeys.to), toDate),
            ],
          ),
        ],
      ),
    );
  }
}
