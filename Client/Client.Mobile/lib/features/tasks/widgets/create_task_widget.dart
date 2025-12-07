import 'package:athr_hr/core/localization/lang_keys.dart';
import 'package:athr_hr/core/routes/app_routes.dart';
import 'package:athr_hr/core/utils/extension/my_context.dart';
import 'package:athr_hr/core/widgets/custom_app_bar_row.dart';
import 'package:athr_hr/features/leaves/widgets/build_optional_note.dart';
import 'package:athr_hr/features/leaves/widgets/upload_attachments.dart';
import 'package:athr_hr/features/tasks/widgets/build_task_date_form_field.dart';
import 'package:athr_hr/features/tasks/widgets/build_task_priority.dart';
import 'package:athr_hr/features/tasks/widgets/create_task_and_assign_to.dart';
import 'package:athr_hr/generated/assets.dart';
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class CreateTaskWidget extends StatefulWidget {
   const CreateTaskWidget({super.key});

   @override
   State<CreateTaskWidget> createState() => _CreateTaskWidgetState();
 }

 class _CreateTaskWidgetState extends State<CreateTaskWidget> {
   @override
   Widget build(BuildContext context) {
     return SingleChildScrollView(
       child: Padding(
         padding: EdgeInsets.all(8.sp),
         child: Column(
           children: [
             SizedBox(height: 10.h),
             CustomAppBarRow(
               title: context.translate(LangKeys.addTask),
               trailing: Image.asset(
                 Assets.imagesArrow,
                 width: 24.w,
                 height: 24.h,
                 fit: BoxFit.contain,
               ),
               onPressed: (){
                 Navigator.of(context).pop();
               },
             ),
             SizedBox(height: 24.h),
             CreateTaskAndAssignTo(),
             BuildTaskPriority(),
             BuildTaskDateFormField(),
             BuildOptionalNote(
               titleText: context.translate(LangKeys.taskDescription),
               hintText: context.translate(LangKeys.enterTaskDescription),
             ),
             SizedBox(height: 24.h,),
             UploadAttachmentsWidget(
               pdfIconPath: Assets.imagesPdffile,
               downloadIconPath: Assets.imagesDownloadpdf,
               uploadButtonImagePath: Assets.imagesAttachmentsbutton,
               prefixText: context.translate(LangKeys.requirementsFile),
               submitText:context.translate(LangKeys.createTask),
               titleText:  context.translate(LangKeys.attachments),
               onSubmit: (){
                 Navigator.pushNamed(context, AppRoutes.tasksDetailsView);
               },
             ),
             SizedBox(height: 20.h,),
           ],
         ),
       ),
     );
   }
 }
