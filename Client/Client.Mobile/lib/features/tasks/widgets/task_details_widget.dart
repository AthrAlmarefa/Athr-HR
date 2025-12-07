import 'package:athr_hr/core/localization/lang_keys.dart';
import 'package:athr_hr/core/styles/colors/my_colors.dart';
import 'package:athr_hr/core/utils/extension/my_context.dart';
import 'package:athr_hr/core/widgets/custom_app_bar_row.dart';
import 'package:athr_hr/features/tasks/widgets/build_assigned_by_row.dart';
import 'package:athr_hr/features/tasks/widgets/build_assigned_to.dart';
import 'package:athr_hr/features/tasks/widgets/build_buttons_row.dart';
import 'package:athr_hr/features/tasks/widgets/build_delivery_date.dart';
import 'package:athr_hr/features/tasks/widgets/build_percentage_progress.dart';
import 'package:athr_hr/features/tasks/widgets/build_task_description_and_priority.dart';
import 'package:athr_hr/features/tasks/widgets/build_task_name_row.dart';
import 'package:athr_hr/features/tasks/widgets/build_tasks_attachments_row.dart';
import 'package:athr_hr/generated/assets.dart';
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class TaskDetailsWidget extends StatefulWidget {
  const TaskDetailsWidget({super.key});

  @override
  State<TaskDetailsWidget> createState() => _TaskDetailsWidgetState();
}

class _TaskDetailsWidgetState extends State<TaskDetailsWidget> {
  @override
  Widget build(BuildContext context) {
    return SafeArea(
      child: Scaffold(
        backgroundColor: MyColors.white,
        body: SingleChildScrollView(
          child: Padding(
            padding: EdgeInsets.all(12.sp),
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                SizedBox(height: 10.h),
                CustomAppBarRow(
                  title: context.translate(LangKeys.taskDetails),
                  trailing: Image.asset(
                    Assets.imagesArrow,
                    width: 24.w,
                    height: 24.h,
                    fit: BoxFit.contain,
                  ),
                  onPressed: () {
                    Navigator.of(context).pop();
                  },
                ),
                SizedBox(height: 24.h),
                BuildTaskNameRow(),
                SizedBox(height: 20.h),
                BuildTaskDescriptionAndPriority(),
                SizedBox(height: 20.h),
                BuildAssignedByRow(),
                SizedBox(height: 20.h),
                AssignAvatars(
                  images: [
                    Assets.imagesAssigndbyphoto,
                    Assets.imagesAssigndbyphoto,
                    Assets.imagesAssigndbyphoto,
                    Assets.imagesAssigndbyphoto,
                  ],
                  maxVisible: 2,
                ),
                BuildPercentageProgress(),
                BuildDeliveryDate(),
                BuildTasksAttachmentsRow(),
                SizedBox(height: 24.h,),
                BuildButtonsRow(),
                SizedBox(height: 24.h,),
              ],
            ),
          ),
        ),
      ),
    );
  }
}
